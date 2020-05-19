using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Common.Factories
{
    public static class SearchRequestFactory
    {
        public static ISearchRequest Create(string searchTerm)
        {
            return new SearchRequest(searchTerm);
        }
    }
}