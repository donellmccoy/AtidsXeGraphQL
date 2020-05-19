using GraphQL.DataLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.Data.Respositories
{
    public interface IGenericRepository
    {
        Task<IDictionary<TKey, TSource>> BatchLoaderSourceAsync<TKey, TSource>(IEnumerable<TKey> keys, Expression<Func<TSource, TKey>> keySelector, CancellationToken token = default) where TSource : class;
        Task<IDictionary<(int, int), TSource>> BatchLoaderSourceAsync<TSource>(IEnumerable<(int, int)> keys, Expression<Func<TSource, (int, int)>> keySelector, CancellationToken token = default) where TSource : class;
        Task<ILookup<TKey, TSource>> CollectionBatchLoaderSourceAsync<TKey, TSource>(IEnumerable<TKey> keys, Expression<Func<TSource, TKey>> keySelector) where TSource : class;
        Task<IEnumerable<TReturnType>> LoadCollectionAsync<TKey, TReturnType>(
            string fieldName,
            TKey key,
            Expression<Func<TReturnType, TKey>> keySelector)
            where TReturnType : class;
        IDataLoader<TKey, TSource> LoadObjectAsync<TKey, TSource>(string fieldName, Expression<Func<TSource, TKey>> keySelector) where TSource : class;
        IDataLoader<(int, int), TSource> LoadObjectAsync<TSource>(string fieldName, Expression<Func<TSource, (int, int)>> keySelector) where TSource : class;
    }
}
