using CleanArchitectrure.Application.Interface.Infrastructure;
using CleanArchitectrure.Application.Interface.Persistence;
using CleanArchitectrure.Domain.Commons;
using CleanArchitectrure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectrure.Persistence.Repositories.Cached
{
    public class CachedGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly IRedisClient _redisClient;
        private readonly AppDbContext _ctx;
        private readonly DbSet<TEntity> _dbSet;
        private readonly string cacheTypeKey = typeof(TEntity).FullName;

        public CachedGenericRepository(IRedisClient redisClient, 
                                        AppDbContext context)
        {
            _redisClient = redisClient;
            _ctx = context;
            _dbSet = _ctx.Set<TEntity>();
        }

        public Task DeleteAsync(string id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity?> FindSingleById(int id, CancellationToken ct)
        {
            var cacheKey = $"{cacheTypeKey}_{id}";
            var result = _redisClient.Get<TEntity>(cacheKey);

            if (result != null)
                return result;

            result = await _dbSet.SingleOrDefaultAsync(o => o.Id == id, ct);
            _redisClient.Set<TEntity>(cacheKey, result);
            return result;
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
