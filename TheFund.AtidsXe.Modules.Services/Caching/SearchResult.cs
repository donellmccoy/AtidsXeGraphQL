using Nito.Comparers;
using System.Linq;

namespace TheFund.AtidsXe.Modules.Services.Caching
{
    public sealed class SearchInfo : ComparableBase<SearchInfo>, ISearchResult
    {
        public string SearchTerm { get; }

        public string JsonResult { get; }

        static SearchInfo()
        {
            DefaultComparer = ComparerBuilder.For<SearchInfo>().OrderBy(p => p.SearchTerm);
        }

        public SearchInfo(string searchTerm, string jsonResult)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                throw new System.ArgumentException("message", nameof(searchTerm));
            }

            SearchTerm = searchTerm;
            JsonResult = jsonResult;
        }
    }
}
