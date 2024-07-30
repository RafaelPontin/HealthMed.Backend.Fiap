using HealthMed.Backend.Aplicacao.Contratos.Persistencia;
using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Infraestrutura.Persistencia;

namespace HealthMed.Backend.Infraestrutura.Repositorio;
public class AgendamentoRepository : RepositoryBase<Agendamentos>, IAgendamentosRepository
{
    public AgendamentoRepository(HealthMedContext dbContext) : base(dbContext)
    {
    }
    

}
