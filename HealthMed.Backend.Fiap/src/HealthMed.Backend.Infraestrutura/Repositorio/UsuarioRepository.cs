using HealthMed.Backend.Aplicacao.Contratos.Persistencia;
using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Backend.Infraestrutura.Repositorio
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(HealthMedContext dbContext) : base(dbContext)
        {
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            return await _dbContext.Usuario.Where(x => x.Email.EnderecoEmail == email).FirstOrDefaultAsync();

        }
    }
}
