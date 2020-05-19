using GraphQL.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.Data.Services
{
    public interface IEFDataStore : IDataStore
    {
        Task<IEnumerable<TEntity>> GetBatchedEntitiesAsync<TKey, TEntity>(string loaderKey,
            TKey key,
            Expression<Func<TEntity, TKey>> keySelector) where TEntity : class;

        Task<IEnumerable<TEntity>> GetBatchedEntitiesAsync<TEntity>(string loaderKey, int key, Expression<Func<TEntity, int>> keySelector, CancellationToken token = default) where TEntity : class;
        Task<TEntity> LoadBatchedEntityAsync<TKey, TEntity>(string loaderKey, TKey key, Func<TEntity, TKey> keySelector) where TEntity : class;
        Task<TEntity> LoadBatchedEntityAsync<TEntity>(string loaderKey, int key, Func<TEntity, int> keySelector) where TEntity : class;
        Task<TEntity> LoadBatchedEntityAsync<TEntity>(string loaderKey, int key, Func<TEntity, int> keySelector, IDataLoaderContextAccessor accessor) where TEntity : class;
    }
}