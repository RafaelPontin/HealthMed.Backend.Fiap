using HealthMed.Backend.Aplicacao.Comunicacao;
using HealthMed.Backend.Aplicacao.DTOs.Agendamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Backend.Aplicacao.Contratos.Servico;
public interface IAgendamentoService
{
    Task<ResponseResult<List<AgendamentoResponseDto>>> ObterAgendamentosPorPaciente(Guid idPaciente);
    Task<ResponseResult<bool>> NovoAgendamento(NovoAgendamentoDto dto, Guid idPaciente);
    Task<ResponseResult<bool>> CancelarAgendamento(Guid idAgendamento, Guid idPaciente);
}
