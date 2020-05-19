using Ensure;
using TheFund.AtidsXe.Modules.Common.Constants;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public sealed class SearchRequest : ISearchRequest
    {
        public SearchRequest(string searchTerm)
        {
            searchTerm.EnsureNotNullOrWhitespace();
            SearchTerm = searchTerm;
        }

        public string SearchTerm { get; }

        public string CacheRegion => CacheRegions.SearchTerms;
    }
}