using HealthMed.Backend.Aplicacao.Contratos.Persistencia;
using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Backend.Infraestrutura.Repositorio;
public class AgendamentoRepository : RepositoryBase<Agendamentos>, IAgendamentosRepository
{
    public AgendamentoRepository(HealthMedContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<IEnumerable<Agendamentos>> ObterPorPacienteAsync(Guid idPaciente)
    {
        return await _dbContext.Agendamentos
            .Include(a => a.Paciente)
            .Include(a => a.Horario)
            .Where(a => a.Paciente.Id == idPaciente)
            .ToListAsync();
    }

}
