using HealthMed.Backend.Dominio.Entidades;

namespace HealthMed.Backend.Aplicacao.Contratos.Persistencia
{
    public interface IRepositoryBase<TEntity> where TEntity : Base
    {
        Task<IReadOnlyList<TEntity>> ObterTodosAsync();
        Task<TEntity> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(TEntity entity);
        Task AlterarAsync(TEntity entity);
        Task DeletarAsync(TEntity entity);
        IQueryable<TEntity> ObterIQueryable();
    }
}