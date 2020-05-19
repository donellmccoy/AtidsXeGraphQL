using TheFund.AtidsXe.Modules.Services.Models;

namespace TheFund.AtidsXe.Modules.Services.Factories
{
    public static class SearchCacheItemFactory
    {
        public static ISearchCacheItem Create(string searchTerm, string fileReferenceJson)
        {
            return new SearchCacheItem(searchTerm, fileReferenceJson);
        }
    }
}