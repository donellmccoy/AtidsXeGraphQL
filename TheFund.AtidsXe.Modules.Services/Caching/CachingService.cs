using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading.Tasks;
using Ensure;
using TheFund.AtidsXe.Modules.Common.Caching;

namespace TheFund.AtidsXe.Modules.Services.Caching
{
    [Export(typeof(ICachingService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class CachingService: ICachingService
    {
        private readonly ITaskCache _cache;

        [ImportingConstructor]
        public CachingService(ITaskCache cache)
        {
            _cache = cache;
        }

        public void Remove(IEnumerable<string> keys)
        {
            foreach (var key in keys)
            {
                key.EnsureNotNullOrWhitespace();
                _cache.Remove(key);
            }
        }

        public void Remove(IEnumerable<int> keys)
        {
            foreach (var key in keys)
            {
                Remove(key.ToString());
            }
        }

        public void Remove(int key)
        {
            Remove(key.ToString());
        }

        public void Remove(string key)
        {
            key.EnsureNotNullOrWhitespace();

            _cache.Remove(key);
        }

        public void Remove(string key, string region)
        {
            key.EnsureNotNullOrWhitespace();
            region.EnsureNotNullOrWhitespace();

            _cache.Remove(key, region);
        }

        public void Remove(int key, string region)
        {
            region.EnsureNotNullOrWhitespace();

            _cache.Remove(key.ToString(), region);
        }

        public async Task<T> RemoveAsync<T>(string key, string region, Func<Task<T>> deleteValueFactory)
        {
            key.EnsureNotNullOrWhitespace();
            region.EnsureNotNullOrWhitespace();

            _cache.Remove(key, region);

            return await deleteValueFactory();
        }

        public async Task<T> RemoveAsync<T>(int key, string region, Func<Task<T>> deleteValueFactory)
        {
            region.EnsureNotNullOrWhitespace();

            _cache.Remove(key.ToString(), region);

            return await deleteValueFactory();
        }

        public async Task<T> AddOrGetExistingAsync<T>(int key, Func<Task<T>> valueFactory)
        {
            valueFactory.EnsureNotNull();

            return await AddOrGetExistingAsync(key.ToString(), valueFactory);
        }

        public async Task<T> AddOrGetExistingAsync<T>(int key, string region, Func<Task<T>> valueFactory)
        {
            region.EnsureNotNullOrWhitespace();
            valueFactory.EnsureNotNull();

            return await AddOrGetExistingAsync(key.ToString(), region, valueFactory);
        }

        public async Task<T> AddOrGetExistingAsync<T>(string key, Func<Task<T>> valueFactory)
        {
            key.EnsureNotNullOrWhitespace();
            valueFactory.EnsureNotNull();

            return await _cache.AddOrGetExistingAsync(key, valueFactory);
        }

        public async Task<T> AddOrGetExistingAsync<T>(string key, string region, Func<Task<T>> valueFactory)
        {
            key.EnsureNotNullOrWhitespace();
            region.EnsureNotNullOrWhitespace();
            valueFactory.EnsureNotNull();

            return await _cache.AddOrGetExistingAsync(key, region, valueFactory);
        }

        public async ValueTask<T> AddOrGetExistingAsync<T>(string key, string region, Func<ValueTask<T>> valueFactory)
        {
            key.EnsureNotNullOrWhitespace();
            region.EnsureNotNullOrWhitespace();
            valueFactory.EnsureNotNull();

            return await _cache.AddOrGetExistingAsync(key, region, valueFactory);
        }
    }
}
