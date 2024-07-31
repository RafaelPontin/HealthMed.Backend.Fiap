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

        public async Task<List<Usuario>> BuscarMedicos()
        {
            return await _dbContext.Usuario.Where(x => x.TipoUsuario == Dominio.Enum.ETipoUsuario.Medico).ToListAsync();
        }

        public async Task<Usuario> Login(string email, string senha)
        {
            return await _dbContext.Usuario.Where(x => x.Email.EnderecoEmail == email && x.Senha == senha).FirstOrDefaultAsync();
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            return await _dbContext.Usuario.Where(x => x.Email.EnderecoEmail == email).FirstOrDefaultAsync();
        }

        public async Task<List<Horarios>> ObterAgenda(Guid id)
        {
            var lista = await 
                _dbContext.Usuario
                .Where(x => x.Id == id)
                .SelectMany(x => x.Horarios)
                .Where(x => x.Disponivel)
                .Include(x => x.Medico)
                .ToListAsync();
            return lista;
        }
    }
}
