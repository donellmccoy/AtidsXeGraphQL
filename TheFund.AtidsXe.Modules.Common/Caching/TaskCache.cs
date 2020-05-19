using CacheManager.Core;
using CacheManager.Core.Internal;
using System;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using Ensure;
using DynamicData;
using System.Threading;
using System.Collections.Concurrent;

namespace TheFund.AtidsXe.Modules.Common.Caching
{
    /// <summary>
    /// TaskCache class
    /// Inline Cache: Read-Through
    /// </summary>
    [Export(typeof(ITaskCache))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class TaskCache : ITaskCache
    {
        private readonly ICacheManager<object> _cacheManager;
        private readonly SourceCache<object, string> _cache;
        private ConcurrentDictionary<object, SemaphoreSlim> _locks = new ConcurrentDictionary<object, SemaphoreSlim>();

        public TaskCache()
        {
            //_cache = new SourceCache<object, string>();

            _cacheManager = CacheFactory.Build
            (
                "GraphQLCache", 
                settings =>
                {
                    settings
                        .WithUpdateMode(CacheUpdateMode.None)
                        .WithSystemRuntimeCacheHandle("atidsxe")
                        .WithExpiration(ExpirationMode.Sliding, new TimeSpan(8, 0, 0));
                            
                });

            _cacheManager.OnRemoveByHandle += CacheManager_OnRemoveByHandle;
        }

        private static void CacheManager_OnRemoveByHandle(object sender, CacheItemRemovedEventArgs e)
        {
            if (e.Reason == CacheItemRemovedReason.Expired)
            {
                //_cacheManager.GetOrAdd(e.Key, e.Region, e.Value);
            }
        }

        public async Task<T> AddOrGetExistingAsync<T>(string key, Func<Task<T>> valueFactory)
        {
            key.EnsureNotNullOrWhitespace();
            valueFactory.EnsureNotNull();

            var asyncLazyValue = new AsyncLazy<T>(valueFactory);
            var existingAsyncLazyValue = (AsyncLazy<T>)_cacheManager.GetOrAdd(key, asyncLazyValue);

            if (existingAsyncLazyValue != null)
            {
                asyncLazyValue = existingAsyncLazyValue;
            }

            try
            {
                var result = await asyncLazyValue;

                // The awaited Task has completed. Check that the task is still the same version
                // that the cache returns (i.e. the awaited task has not been invalidated during the await).
                if (asyncLazyValue != _cacheManager.GetOrAdd(key, new AsyncLazy<T>(valueFactory)))
                {
                    // The awaited value is not the most recent one,
                    // therefore, get the most recent value with a recursive call.
                    return await AddOrGetExistingAsync(key, valueFactory);
                }

                return result;
            }
            catch (Exception)
            {
                _cacheManager.Remove(key);
                throw;
            }
        }

        public async Task<T> AddOrGetExistingAsync<T>(string key, string region, Func<Task<T>> valueFactory)
        {
            key.EnsureNotNullOrWhitespace();
            region.EnsureNotNullOrWhitespace();
            valueFactory.EnsureNotNull();

            var asyncLazyValue = new AsyncLazy<T>(valueFactory);

            //Note: existingValue could be either a running task or a completed task
            if (_cacheManager.GetOrAdd(key, region, asyncLazyValue) is AsyncLazy<T> existingValue)
            {
                asyncLazyValue = existingValue;
            }

            try
            {
                //Get value from backing store using the valueFactory if the value in the
                //async lazy type has not been already accessed once. If it has been accessed
                //once then just the return the value in the async lazy type.
                var value = await asyncLazyValue;

                // If the code reaches this point, awaited Task has completed. Check that the task is still the same version
                // that the cache returns (i.e. the awaited task has not been invalidated or removed during the await).
                if (asyncLazyValue != _cacheManager.GetOrAdd(key, region, new AsyncLazy<T>(valueFactory)))
                {
                    // The awaited value is not the most recent one,
                    // therefore, get the most recent value with a recursive call.
                    return await AddOrGetExistingAsync(key, region, valueFactory);
                }

                return value;
            }
            catch (Exception)
            {
                _cacheManager.Remove(key, region);
                throw;
            }
        }

        public async ValueTask<T> AddOrGetExistingAsync<T>(string key, string region, Func<ValueTask<T>> valueFactory)
        {
            key.EnsureNotNullOrWhitespace();
            region.EnsureNotNullOrWhitespace();
            valueFactory.EnsureNotNull();

            Func<Task<T>> func = () => valueFactory.Invoke().AsTask();

            var asyncLazyValue = new AsyncLazy<T>(func);
            var existingValue = (AsyncLazy<T>)_cacheManager.GetOrAdd(key, region, asyncLazyValue);

            //Note: existingValue could be either a running task or a completed task
            if (existingValue != null)
            {
                asyncLazyValue = existingValue;
            }

            try
            {
                //Get value from backing store using the valueFactory if the value in the
                //async lazy type has not been already accessed once. If it has been accessed
                //once then just the return the value in the async lazy type.
                var value = await asyncLazyValue;

                // If the code reaches this point, awaited Task has completed. Check that the task is still the same version
                // that the cache returns (i.e. the awaited task has not been invalidated or removed during the await).
                if (asyncLazyValue != _cacheManager.GetOrAdd(key, region, new AsyncLazy<T>(func)))
                {
                    // The awaited value is not the most recent one,
                    // therefore, get the most recent value with a recursive call.
                    return await AddOrGetExistingAsync(key, region, valueFactory);
                }

                return value;
            }
            catch (Exception)
            {
                _cacheManager.Remove(key, region);
                throw;
            }
        }

        public void InValidate(string key, string region, ExpirationMode expirationMode = ExpirationMode.None, TimeSpan timeSpan = default)
        {
            _cacheManager.Expire(key, region, expirationMode, timeSpan);
        }

        public void Remove(string key)
        {
            _cacheManager.Remove(key);
        }

        public void Remove(string key, string region)
        {
            _cacheManager.Remove(key, region);
        }

        public bool Contains(string key)
        {
            return _cacheManager.Exists(key);
        }

        public bool Contains(string key, string region)
        {
            return _cacheManager.Exists(key, region);
        }

        public void Clear()
        {
            _cacheManager.Clear();
        }
    }
}
