using DynamicData;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Services.Factories;
using TheFund.AtidsXe.Modules.Services.Models;

namespace TheFund.AtidsXe.Modules.Services.Caching
{
    [Export(typeof(ISearchCachingService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class SearchCachingService : ISearchCachingService
    {
        private readonly ISourceCache<ISearchCacheItem, string> _cache;

        public IObservableCache<ISearchCacheItem, string> Cache => _cache.AsObservableCache();

        public SearchCachingService()
        {
            _cache = new SourceCache<ISearchCacheItem, string>(cacheItem => cacheItem.SearchTerm);
        }

        public void Refresh()
        {
            _cache.Refresh();
        }

        public void Refresh(ISearchCacheItem item)
        {
            _cache.Refresh(item);
        }

        public ISearchCacheItem Lookup(string key)
        {
            var item = _cache.Lookup(key);
            return item.HasValue ? item.Value : null;
        }

        public bool IsCached(string key)
        {
            return _cache.Lookup(key).HasValue;
        }

        public void AddOrUpdate(ISearchCacheItem item)
        {
            _cache.AddOrUpdate(item);
        }

        public ISearchCacheItem AddOrUpdate(string searchTerm, string fileReferenceJson)
        {
            var cacheItem = SearchCacheItemFactory.Create(searchTerm, fileReferenceJson);
            _cache.AddOrUpdate(cacheItem);
            return cacheItem;
        }

        public void AddOrUpdate(IEnumerable<ISearchCacheItem> items)
        {
            _cache.AddOrUpdate(items);
        }
    }
}
