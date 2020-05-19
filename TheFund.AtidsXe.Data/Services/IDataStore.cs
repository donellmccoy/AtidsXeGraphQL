using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.Data.Services
{
    public interface IDataStore
    {
        Task<int> GetEntityCountAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default) where TEntity : class;
        TEntity GetEntity<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<TEntity> GetEntityAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default) where TEntity : class;
        IEnumerable<TEntity> GetEntities<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;
        Task<IEnumerable<TEntity>> GetEntitiesAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default) where TEntity : class;
        Task<TEntity> UpdateEntity<TEntity>(TEntity entity, CancellationToken token = default) where TEntity : class;
        Task<TEntity> DeleteEntity<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default) where TEntity : class;
    }
}
