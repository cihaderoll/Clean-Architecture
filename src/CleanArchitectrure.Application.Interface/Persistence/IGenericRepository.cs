using System.Linq.Expressions;

namespace CleanArchitectrure.Application.Interface.Persistence
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /* Commands */

        #region Commands

        Task InsertAsync(TEntity entity, CancellationToken ct);
        void Update(TEntity entity);
        Task DeleteAsync(string id, CancellationToken ct);

        #endregion Commands

        #region Queries

        Task<TEntity> GetAsync(string id, CancellationToken ct);
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct);
        Task<TEntity?> FindSingle(Expression<Func<TEntity?, bool>> predicate, CancellationToken ct);
        Task<TEntity?> FindSingleById(int id, CancellationToken ct);

        #endregion Queries
    }
}
