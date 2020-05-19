using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Services.Models;

namespace TheFund.AtidsXe.Modules.Services.Caching
{
    public interface ISearchCachingService
    {
        void AddOrUpdate(ISearchCacheItem item);
        void AddOrUpdate(IEnumerable<ISearchCacheItem> items);
        ISearchCacheItem AddOrUpdate(string searchTerm, string fileReferenceJson);
        bool IsCached(string key);
        ISearchCacheItem Lookup(string key);
        void Refresh();
        void Refresh(ISearchCacheItem item);
    }
}
