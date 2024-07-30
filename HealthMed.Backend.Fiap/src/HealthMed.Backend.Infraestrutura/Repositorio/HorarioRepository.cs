using HealthMed.Backend.Aplicacao.Contratos.Persistencia;
using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Infraestrutura.Persistencia;

namespace HealthMed.Backend.Infraestrutura.Repositorio
{
    public class HorarioRepository : RepositoryBase<Horarios>, IHorarioRepository
    {
        public HorarioRepository(HealthMedContext dbContext) : base(dbContext)
        {
        }

        public async Task<int> GetQuantidadeHorariosPorMedico(DateTime dataInicio, DateTime dataFim, Guid idMedico)
        {
            int quantidade = _dbContext.Horarios.Where(h => (h.Medico.Id == idMedico) &&
                                                               ((dataInicio >= h.HorarioInicio && dataInicio <= h.HorarioFinal) ||
                                                                (dataFim >= h.HorarioInicio && dataFim <= h.HorarioFinal) ||
                                                                (h.HorarioInicio >= dataInicio && h.HorarioInicio <= dataFim) ||
                                                                (h.HorarioFinal >= dataInicio && h.HorarioFinal <= dataFim))).Count();
            return quantidade;
        }
    }
}
