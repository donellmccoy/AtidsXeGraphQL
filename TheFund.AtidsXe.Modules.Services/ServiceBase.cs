using System.Threading;
using System.Threading.Tasks;
using ReactiveUI;
using TheFund.AtidsXe.Modules.Services.Caching;

namespace TheFund.AtidsXe.Modules.Services
{
    public abstract class ServiceBase : ReactiveObject
    {
        private readonly ICachingServiceV3 _cachingService;

        public ServiceBase(ICachingServiceV3 cachingService)
        {
            _cachingService = cachingService;
        }

        protected void RemoveItem(int key, string region)
        {
            RemoveItem(key.ToString(), region);
        }

        protected void RemoveItem(string key, string region)
        {
            _cachingService.RemoveItem(key, region);
        }

        protected void AddItem(string key, object value, string region)
        {
            _cachingService.AddItem(key, value, region);
        }

        protected Task AddItemAsync(string key, object value, string region, CancellationToken token = default)
        {
            return Task.Run(() => _cachingService.AddItem(key, value, region), token);
        }

        protected void AddItem(int key, object value, string region)
        {
            _cachingService.AddItem(key, value, region);
        }

        protected Task AddItemAsync(int key, object value, string region, CancellationToken token = default)
        {
            return Task.Run(() => _cachingService.AddItem(key, value, region), token);
        }

        protected TOut GetItem<TOut>(string key, string region)
        {
            return _cachingService.GetItem<TOut>(key, region);
        }

        protected Task<TOut> GetItemAsync<TOut>(string key, string region, CancellationToken token = default)
        {
            return Task.Run(() => _cachingService.GetItem<TOut>(key, region), token);
        }

        protected TOut GetItem<TOut>(int key, string region)
        {
            return _cachingService.GetItem<TOut>(key, region);
        }

        protected Task<TOut> GetItemAsync<TOut>(int key, string region, CancellationToken token = default)
        {
            return Task.Run(() => _cachingService.GetItem<TOut>(key, region), token);
        }

        protected bool IsCached(string key, string region)
        {
            return _cachingService.IsCached(key, region);
        }

        protected Task<bool> IsCachedAsync(string key, string region, CancellationToken token = default)
        {
            return Task.Run(() => _cachingService.IsCached(key, region), token);
        }

        protected bool IsCached(int key, string region)
        {
            return _cachingService.IsCached(key, region);
        }

        protected Task<bool> IsCachedAsync(int key, string region, CancellationToken token = default)
        {
            return Task.Run(() => _cachingService.IsCached(key, region), token);
        }
    }
}
