using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Services
{
    public sealed class EFDataStore : DataStore, IEFDataStore
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDataLoaderContextAccessor _accessor;

        public EFDataStore(IServiceProvider serviceProvider, IDataLoaderContextAccessor accessor)
        {
            _serviceProvider = serviceProvider;
            _accessor = accessor;
        }

        public EFDataStore(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override async Task<TEntity> DeleteEntity<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default)
        {
            TEntity entity;

            await using (var context = _serviceProvider.GetService<ATIDSXEContext>())
            {
                entity = await context.Set<TEntity>().SingleOrDefaultAsync(predicate, token).ConfigureAwait(false);
                if (entity != null)
                {
                    context.Remove(entity);
                    await context.SaveChangesAsync(token).ConfigureAwait(false);
                }
            }

            return entity;
        }

        public override async Task<TEntity> UpdateEntity<TEntity>(TEntity entity, CancellationToken token = default)
        {
            await using (var context = _serviceProvider.GetService<ATIDSXEContext>())
            {
                context.Set<TEntity>().Attach(entity);
                context.Entry<TEntity>(entity);
                await context.SaveChangesAsync(token).ConfigureAwait(false);
            }

            return entity;
        }

        public override TEntity GetEntity<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            TEntity entity;
            using (var context = _serviceProvider.GetService<ATIDSXEContext>())
            {
                entity = context.Set<TEntity>().FirstOrDefault(predicate);
            }
            return entity;
        }

        public override async Task<int> GetEntityCountAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }

            int count;

            await using (var context = _serviceProvider.GetService<ATIDSXEContext>())
            {
                count = await context.Set<TEntity>().CountAsync(predicate, token);
            }

            return count;
        }

        public override async Task<TEntity> GetEntityAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            TEntity entity;
            await using (var context = _serviceProvider.GetService<ATIDSXEContext>())
            {
                entity = await context.Set<TEntity>().FirstOrDefaultAsync(predicate, token);
            }
            return entity;
        }

        public override IEnumerable<TEntity> GetEntities<TEntity>(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            IEnumerable<TEntity> entities;
            using (var context = _serviceProvider.GetService<ATIDSXEContext>())
            {
                entities = context.Set<TEntity>().Where(predicate).ToList();
            }
            return entities;
        }

        public override async Task<IEnumerable<TEntity>> GetEntitiesAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            IEnumerable<TEntity> entities;
            await using (var context = _serviceProvider.GetService<ATIDSXEContext>())
            {
                entities = await context.Set<TEntity>().Where(predicate).ToListAsync(token);
            }
            return entities;
        }

        public Task<IEnumerable<TEntity>> GetBatchedEntitiesAsync<TKey, TEntity>(string loaderKey, TKey key, Expression<Func<TEntity, TKey>> keySelector) where TEntity : class
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }
            if (string.IsNullOrWhiteSpace(loaderKey))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(loaderKey));
            }

            return _accessor.Context.GetOrAddCollectionBatchLoader<TKey, TEntity>
            (
                loaderKey,
                async (entityIds, token) =>
                {
                    var selector = keySelector.Compile();
                    var entities = await GetEntitiesAsync<TEntity>(entity => entityIds.Contains(selector(entity)), token).ConfigureAwait(false);

                    return entities?.ToLookup(selector);
                }
            ).LoadAsync(key);
        }

        public Task<IEnumerable<TEntity>> GetBatchedEntitiesAsync<TKey, TEntity>(string loaderKey, TKey key, Func<TEntity, TKey> keySelector) where TEntity : class
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }
            if (string.IsNullOrWhiteSpace(loaderKey))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(loaderKey));
            }

            return _accessor.Context.GetOrAddCollectionBatchLoader<TKey, TEntity>
            (
                loaderKey,
                async (entityIds, token) =>
                {
                    if (entityIds == null)
                    {
                        throw new ArgumentNullException(nameof(entityIds));
                    }

                    var selector = keySelector;
                    var entities = await GetEntitiesAsync<TEntity>(entity => entityIds.Contains(keySelector(entity)), token).ConfigureAwait(false);
                    return entities?.ToLookup(selector);
                }
            ).LoadAsync(key);
        }

        public Task<IEnumerable<TEntity>> GetBatchedEntitiesAsync<TEntity>(string loaderKey, int key, Expression<Func<TEntity, int>> keySelector, CancellationToken token = default(CancellationToken)) where TEntity : class
        {
            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }
            if (string.IsNullOrWhiteSpace(loaderKey))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(loaderKey));
            }
            if (key <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(key));
            }

            return GetBatchedEntitiesAsync(loaderKey, key, keySelector);
        }

        public Task<TEntity> LoadBatchedEntityAsync<TEntity>(string loaderKey, int key, Func<TEntity, int> keySelector) where TEntity : class
        {
            if (keySelector == null)
            {
                throw new ArgumentNullException(nameof(keySelector));
            }
            if (string.IsNullOrWhiteSpace(loaderKey))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(loaderKey));
            }
            if (key <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(key));
            }

            return LoadBatchedEntityAsync<int, TEntity>(loaderKey, key, keySelector);
        }

        public Task<TEntity> LoadBatchedEntityAsync<TKey, TEntity>(string loaderKey, TKey key, Func<TEntity, TKey> keySelector) where TEntity : class
        {
            return _accessor.Context.GetOrAddBatchLoader<TKey, TEntity>
            (
                loaderKey,
                async (entityIds, token) =>
                {
                    Dictionary<TKey, TEntity> entities;
                    await using (var context = _serviceProvider.GetService<ATIDSXEContext>())
                    {
                        entities = await context.Set<TEntity>()
                                                .Where(entity => entityIds.Contains(keySelector(entity)))
                                                .ToDictionaryAsync(keySelector, token);
                    }
                    return entities;
                }
            ).LoadAsync(key);
        }

        public Task<TEntity> LoadBatchedEntityAsync<TEntity>(
            string loaderKey, 
            int key, 
            Func<TEntity, int> keySelector, 
            IDataLoaderContextAccessor accessor) where TEntity : class
        {
            return accessor.Context.GetOrAddBatchLoader<int, TEntity>
            (
                loaderKey,
                async (keys, token) =>
                {
                    Dictionary<int, TEntity> dictionary;
                    await using (var context = _serviceProvider.GetService<ATIDSXEContext>())
                    {
                        Expression<Func<TEntity, int>> selector = (Expression<Func<TEntity, int>>)(entity => keySelector(entity));
                        
                        Expression<Func<TEntity, bool>> predicate = (Expression<Func<TEntity, bool>>)(entity => keySelector(entity) == 2);

                        dictionary = await context.Set<TEntity>()
                                                  .Where(predicate)
                                                  .ToDictionaryAsync(keySelector, token);
                    }
                    return dictionary;
                }
            ).LoadAsync(key);
        }
    }
}