using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.Data.Services
{
    public abstract class DataStore
    {
        public abstract Task<int> GetEntityCountAsync<TEntity>([NotNull] Expression<Func<TEntity, bool>> predicate, CancellationToken token = default) where TEntity : class;
        
        public abstract Task<TEntity> DeleteEntity<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default) where TEntity : class;
        
        public abstract Task<TEntity> UpdateEntity<TEntity>(TEntity entity, CancellationToken token = default) where TEntity : class;

        public abstract TEntity GetEntity<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        public abstract Task<TEntity> GetEntityAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default) where TEntity : class;

        public abstract IEnumerable<TEntity> GetEntities<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        public abstract Task<IEnumerable<TEntity>> GetEntitiesAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default) where TEntity : class;
    }
}