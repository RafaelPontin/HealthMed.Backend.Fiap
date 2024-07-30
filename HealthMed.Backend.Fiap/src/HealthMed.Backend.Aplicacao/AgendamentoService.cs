using HealthMed.Backend.Aplicacao.Comunicacao;
using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao;
public class AgendamentoService
{
    private readonly AgendamentoRepository _agendamentoRepository;
    private readonly HorarioRepository _horarioRepository;

    public AgendamentoService(AgendamentoRepository agendamentoRepository, HorarioRepository horarioRepository)
    {
        _agendamentoRepository = agendamentoRepository;
        _horarioRepository = horarioRepository;
    }

    public async Task<ResponseResult<bool>> NovoAgendamento(AgendamentoDto dto)
    {
        var response = new ResponseResult<bool>();

        var horario = await _horarioRepository.ObterPorIdsAsync(dto.Horarios);

        var agendamento = new Agendamentos(dto.Paciente, horario);

        if (agendamento.Erros.Any())
        {
            response.Status = 400;
            response.Erros = agendamento.Erros;
            return response;
        }

        await _agendamentoRepository.AdicionarAsync(agendamento);

        return response;
    }


}
