using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao.Contratos.Persistencia
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> ObterPorEmail(string email);
        Task<Usuario> Login(string email, string senha);
        Task<List<Usuario>> BuscarMedicos();
        Task<List<Horarios>> ObterAgenda(Guid id);
    }
}
