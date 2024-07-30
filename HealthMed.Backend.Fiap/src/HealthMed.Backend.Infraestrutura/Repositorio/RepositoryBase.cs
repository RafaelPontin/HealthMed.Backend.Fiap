using HealthMed.Backend.Aplicacao.Contratos.Persistencia;
using HealthMed.Backend.Dominio.Entidades;
using HealthMed.Backend.Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Backend.Infraestrutura.Repositorio
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Base
    {
        protected readonly HealthMedContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(HealthMedContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<TEntity>();
        }

        public virtual async Task AdicionarAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AlterarAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletarAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public IQueryable<TEntity> ObterIQueryable()
        {
            return _dbSet;
        }

        public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<TEntity>> ObterTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
