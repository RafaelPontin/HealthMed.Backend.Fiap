using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao.Contratos.Persistencia;
public interface IAgendamentosRepository : IRepositoryBase<Agendamentos>
{
    Task<IEnumerable<Agendamentos>> ObterPorPacienteAsync(Guid idPaciente);
}
