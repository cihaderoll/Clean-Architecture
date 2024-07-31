using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Domain.Commons;
using CleanArchitectrure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitectrure.Persistence.Repositories.NonCached
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly AppDbContext _ctx;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _ctx = context;
            _dbSet = _ctx.Set<TEntity>();
        }

        public Task DeleteAsync(string id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity?> FindSingleById(int id, CancellationToken ct)
        {
            return await _dbSet.SingleOrDefaultAsync(o => o.Id == id, ct);
        }

        public async Task<TEntity?> FindSingle(Expression<Func<TEntity?, bool>> predicate, CancellationToken ct)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate, ct);
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(string id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(TEntity entity, CancellationToken ct)
        {
            await _dbSet.AddAsync(entity, ct);
        }

        public void Update(TEntity entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
        }
    }
}
