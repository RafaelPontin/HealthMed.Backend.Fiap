using HealthMed.Backend.Aplicacao.Comunicacao;
using HealthMed.Backend.Aplicacao.Contratos.Persistencia;
using HealthMed.Backend.Aplicacao.Contratos.Servico;
using HealthMed.Backend.Aplicacao.DTOs.Agendamentos;
using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Dominio.Enum;

namespace HealthMed.Backend.Aplicacao;
public class AgendamentoService : IAgendamentoService
{
    private readonly IAgendamentosRepository _agendamentoRepository;
    private readonly IHorarioRepository _horarioRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IEmailService _emailService;

    public AgendamentoService(IAgendamentosRepository agendamentoRepository, IHorarioRepository horarioRepository, IUsuarioRepository usuarioRepository, IEmailService emailService)
    {
        _agendamentoRepository = agendamentoRepository;
        _horarioRepository = horarioRepository;
        _usuarioRepository = usuarioRepository;
        _emailService = emailService;
    }

    public async Task<ResponseResult<List<AgendamentoResponseDto>>> ObterAgendamentosPorPaciente(Guid idPaciente)
    {
        var response = new ResponseResult<List<AgendamentoResponseDto>>();

        var agendamentos = await _agendamentoRepository.ObterPorPacienteAsync(idPaciente);

        response.Data = agendamentos.Select(a => new AgendamentoResponseDto(a)).ToList();

        return response;
    }

    public async Task<ResponseResult<bool>> NovoAgendamento(NovoAgendamentoDto dto, Guid idPaciente)
    {
        var response = new ResponseResult<bool>();

        var horario = await _horarioRepository.ObterPorIdAsync(dto.HorarioId);
        var paciente = await _usuarioRepository.ObterPorIdAsync(idPaciente);


        var agendamento = new Agendamentos(paciente, horario);

        var dadosDoEmail = new EmailAgendamento(horario.Medico.Nome, horario.Medico.Email, paciente.Nome, horario.HorarioInicio, ETipoMensagem.Agendamento);

        if (agendamento.Erros.Any() || dadosDoEmail.Erros.Any())
        {
            var erros = agendamento.Erros.Concat(dadosDoEmail.Erros).ToList();
            response.Status = 400;
            response.Erros = erros;
            return response;
        }

        horario.HorarioIndisponivel();

        await _horarioRepository.AlterarAsync(horario);
        await _agendamentoRepository.AdicionarAsync(agendamento);


        var email = await _emailService.EnviarEmailAsync(dadosDoEmail);

        if (!email)
        {
            response.Status = 200;
            response.Erros.Add("Erro ao enviar email de confirmação, mas a consulta foi agendada com sucesso!");
            response.Data = true;
            return response;
        }
            
        response.Data = true;
        return response;
    }

    public async Task<ResponseResult<bool>> CancelarAgendamento(Guid idAgendamento, Guid idPaciente)
    {
        var response = new ResponseResult<bool>();

        var agendamento = await _agendamentoRepository.ObterPorIdAsync(idAgendamento);

        if (agendamento == null)
        {
            response.Status = 404;
            response.Erros.Add("Agendamento não encontrado");
            return response;
        }

        if (agendamento.Paciente.Id != idPaciente)
        {
            response.Status = 403;
            response.Erros.Add("Você não tem permissão para cancelar este agendamento");
            return response;
        }

        var horario = await _horarioRepository.ObterPorIdAsync(agendamento.Horario.Id);

        horario.HorarioDisponivel();

        var dadosDoEmail = new EmailAgendamento(horario.Medico.Nome, horario.Medico.Email, agendamento.Paciente.Nome, horario.HorarioInicio, ETipoMensagem.Cancelamento);

        if (dadosDoEmail.Erros.Any())
        {
            response.Status = 400;
            response.Erros = dadosDoEmail.Erros;
            return response;
        }

        await _horarioRepository.AlterarAsync(horario);
        await _agendamentoRepository.DeletarAsync(agendamento);

        var email = await _emailService.EnviarEmailAsync(dadosDoEmail);

        if (!email)
        {
            response.Status = 200;
            response.Erros.Add("Erro ao enviar email de cancelamento, mas a consulta foi cancelada com sucesso!");
            response.Data = true;
            return response;
        }

        response.Data = true;
        return response;
    }
}
