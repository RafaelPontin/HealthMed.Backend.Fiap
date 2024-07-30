using HealthMed.Backend.Aplicacao.Comunicacao;
using HealthMed.Backend.Aplicacao.Contratos.Persistencia;
using HealthMed.Backend.Aplicacao.Contratos.Servico;
using HealthMed.Backend.Aplicacao.DTOs.Agendamentos;
using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao;
public class AgendamentoService : IAgendamentoService
{
    private readonly IAgendamentosRepository _agendamentoRepository;
    private readonly IHorarioRepository _horarioRepository;
    private readonly IUsuarioRepository _usuarioRepository;

    public AgendamentoService(IAgendamentosRepository agendamentoRepository, IHorarioRepository horarioRepository, IUsuarioRepository usuarioRepository)
    {
        _agendamentoRepository = agendamentoRepository;
        _horarioRepository = horarioRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<ResponseResult<IEnumerable<AgendamentoResponseDto>>> ObterAgendamentosPorPaciente(Guid idPaciente)
    {
        var response = new ResponseResult<IEnumerable<AgendamentoResponseDto>>();

        var agendamentos = await _agendamentoRepository.ObterPorPacienteAsync(idPaciente);

        response.Data = agendamentos.Select(a => new AgendamentoResponseDto(a));

        return response;
    }

    public async Task<ResponseResult<bool>> NovoAgendamento(NovoAgendamentoDto dto, Guid idPaciente)
    {
        var response = new ResponseResult<bool>();

        var horario = await _horarioRepository.ObterPorIdAsync(dto.HorarioId);
        var paciente = await _usuarioRepository.ObterPorIdAsync(idPaciente);


        var agendamento = new Agendamentos(paciente, horario);

        if (agendamento.Erros.Any())
        {
            response.Status = 400;
            response.Erros = agendamento.Erros;
            return response;
        }

        horario.HorarioIndisponivel();

        await _horarioRepository.AlterarAsync(horario);
        await _agendamentoRepository.AdicionarAsync(agendamento);

        return response;
    }

    public async Task<ResponseResult<bool>> CancelarAgendamento(Guid idAgendamento)
    {
        var response = new ResponseResult<bool>();

        var agendamento = await _agendamentoRepository.ObterPorIdAsync(idAgendamento);

        if (agendamento == null)
        {
            response.Status = 404;
            response.Erros.Add("Agendamento não encontrado");
            return response;
        }

        var horario = await _horarioRepository.ObterPorIdAsync(agendamento.Horario.Id);

        horario.HorarioDisponivel();

        await _horarioRepository.AlterarAsync(horario);
        await _agendamentoRepository.DeletarAsync(agendamento);

        return response;
    }
}
