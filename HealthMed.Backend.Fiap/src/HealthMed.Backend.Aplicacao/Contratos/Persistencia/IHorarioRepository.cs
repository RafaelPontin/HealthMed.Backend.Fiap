using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao.Contratos.Persistencia;
public interface IHorarioRepository : IRepositoryBase<Horarios>
{
    Task<int> GetQuantidadeHorariosPorMedico(DateTime dataInicio, DateTime dataFim, Guid idMedico);
}