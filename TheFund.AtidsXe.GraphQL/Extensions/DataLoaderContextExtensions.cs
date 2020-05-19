using GraphQL.DataLoader;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.GraphQL.Extensions
{
    public static class DataLoaderContextExtensions
    {
        public static IDataLoader<TKey, T> GetOrAddBatchLoader<TKey, T>(this DataLoaderContext context, Func<IEnumerable<TKey>, Task<IDictionary<TKey, T>>> fetchFunc, IEqualityComparer<TKey> keyComparer = null, T defaultValue = default)
        {
            return context.GetOrAddBatchLoader(nameof(fetchFunc.Method.Name), fetchFunc, keyComparer, defaultValue);
        }
    }
}
