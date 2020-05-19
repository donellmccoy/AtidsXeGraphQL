using System;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.Tests
{
    /// <summary>
    /// Implementation of the ICache that uses MemoryCache internally.
    /// </summary>
    public class TaskCache : ITaskCache
    {
        private MemoryCache _cache { get; } = MemoryCache.Default;
        private CacheItemPolicy _defaultPolicy { get; } = new CacheItemPolicy();

        public async Task<T> AddOrGetExisting<T>(string key, Func<Task<T>> valueFactory)
        {
            var asyncLazyValue = new AsyncLazy<T>(valueFactory);
            var existingValue = (AsyncLazy<T>)_cache.AddOrGetExisting(key, asyncLazyValue, _defaultPolicy);

            if (existingValue != null)
            {
                asyncLazyValue = existingValue;
            }

            try
            {
                var result = await asyncLazyValue;

                // The awaited Task has completed. Check that the task still is the same version
                // that the cache returns (i.e. the awaited task has not been invalidated during the await).
                if (asyncLazyValue != _cache.AddOrGetExisting(key, new AsyncLazy<T>(valueFactory), _defaultPolicy))
                {
                    // The awaited value is not the most recent one.
                    // Get the most recent value with a recursive call.
                    return await AddOrGetExisting(key, valueFactory);
                }
                return result;
            }
            catch (Exception)
            {
                // Task object for the given key failed with exception. Remove the task from the cache.
                _cache.Remove(key);
                // Re throw the exception to be handled by the caller.
                throw;
            }
        }

        public void Invalidate(string key)
        {
            _cache.Remove(key);
        }

        public bool Contains(string key)
        {
            return _cache.Contains(key);
        }

        public void Clear()
        {
            // A snapshot of keys is taken to avoid enumerating collection during changes.
            var keys = _cache.Select(i => i.Key).ToList();
            keys.ForEach(k => _cache.Remove(k));
        }
    }
}
