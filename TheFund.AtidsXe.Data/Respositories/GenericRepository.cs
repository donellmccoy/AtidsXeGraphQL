using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using TheFund.AtidsXe.Entities.Models;

namespace TheFund.AtidsXe.Data.Respositories
{
    public sealed class GenericRepository : IGenericRepository
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDataLoaderContextAccessor _accessor;

        public GenericRepository(IServiceProvider serviceProvider, IDataLoaderContextAccessor accessor)
        {
            _serviceProvider = serviceProvider;
            _accessor = accessor;
        }

        public async Task<IDictionary<TKey, TSource>> BatchLoaderSourceAsync<TKey, TSource>(
            IEnumerable<TKey> keys, 
            Expression<Func<TSource, TKey>> keySelector, 
            CancellationToken token = default) where TSource : class
        {
            IDictionary<TKey, TSource> dictionary;

            await using (var context = _serviceProvider.GetService<ATIDSXEContext>())
            {
                dictionary = await context.Set<TSource>()
                                          .Where(keySelector.Compose(key => keys.Contains(key)))
                                          .ToDictionaryAsync(keySelector.Compile(), token);
            }

            return dictionary;
        }

        public async Task<IDictionary<ValueTuple<int, int>, TSource>> BatchLoaderSourceAsync<TSource>(
            IEnumerable<ValueTuple<int, int>> keys,
            Expression<Func<TSource, ValueTuple<int, int>>> keySelector,
            CancellationToken token = default) where TSource : class
        {
            IDictionary<ValueTuple<int, int>, TSource> dictionary;

            await using (var context = _serviceProvider.GetService<ATIDSXEContext>())
            {
                dictionary = await context.Set<TSource>()
                    .Where(p => keys.Select(r => r.Item1).Contains(keySelector.Compile().Invoke(p).Item1))
                    .Where(p => keys.Select(r => r.Item2).Contains(keySelector.Compile().Invoke(p).Item2))
                    .ToDictionaryAsync(keySelector.Compile(), token);
            }

            return dictionary;
        }

        public IDataLoader<ValueTuple<int, int>, TSource> LoadObjectAsync<TSource>(
            string fieldName, 
            Expression<Func<TSource, ValueTuple<int, int>>> keySelector) where TSource : class
        {
            var loaderKey = $"{fieldName}LoaderKey";
            return _accessor.Context.GetOrAddBatchLoader<ValueTuple<int, int>, TSource>
            (
                loaderKey,
                keys => BatchLoaderSourceAsync(keys, keySelector));
        }

        public IDataLoader<TKey, TSource> LoadObjectAsync<TKey, TSource>(
            string fieldName, 
            Expression<Func<TSource, TKey>> keySelector) where TSource : class
        {
            var loaderKey = $"{fieldName}LoaderKey";
            return _accessor.Context.GetOrAddBatchLoader<TKey, TSource>
            (
                loaderKey,
                keys => BatchLoaderSourceAsync(keys, keySelector));
        }

        public async Task<ILookup<TKey, TSource>> CollectionBatchLoaderSourceAsync<TKey, TSource>(
            IEnumerable<TKey> keys, 
            Expression<Func<TSource, TKey>> keySelector) 
            where TSource : class
        {
            ILookup<TKey, TSource> lookup;

            await using (var context = _serviceProvider.GetService<ATIDSXEContext>())
            {
                lookup = (await context.Set<TSource>()
                                       .Where(keySelector.Compose(key => keys.AsEnumerable().Contains(key)))
                                       .ToListAsync())
                                       .ToLookup(keySelector.Compile());
            }

            return lookup;
        }

        public Task<IEnumerable<TReturnType>> LoadCollectionAsync<TKey, TReturnType>(
            string fieldName, 
            TKey key, 
            Expression<Func<TReturnType, TKey>> keySelector)
            where TReturnType : class
        {
            var loaderKey = $"{fieldName}LoaderKey";

            Func<IEnumerable<TKey>, Task<ILookup<TKey, TReturnType>>> fetchFunc =
                keys => CollectionBatchLoaderSourceAsync(keys, keySelector);

            return _accessor.Context
                            .GetOrAddCollectionBatchLoader(loaderKey, fetchFunc)
                            .LoadAsync(key);
        }
    }
}
