using HealthMed.Backend.Aplicacao.Comunicacao;
using HealthMed.Backend.Aplicacao.DTOs.Horario;

namespace HealthMed.Backend.Aplicacao.Contratos.Servico;
public interface IHorarioService
{
    Task<ResponseResult<HorarioResponse>> CadastraHorario(AdicionarHorarioDto dto, Guid idMedico);
    Task<ResponseResult<HorarioResponse>> AlterarHorario(AlterarHorarioDto dto, Guid idMedico);
    Task<ResponseResult<bool>> AlterarHorarioDisponivel(Guid idHorario);
}
