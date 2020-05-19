using Ensure;
using System;

namespace TheFund.AtidsXe.Modules.Services.Models
{
    public sealed class SearchCacheItem : ISearchCacheItem
    {
        public SearchCacheItem(string searchTerm, string fileReferenceJson)
        {
            searchTerm.EnsureNotNullOrWhitespace();
            fileReferenceJson.EnsureNotNullOrWhitespace();

            SearchTerm = searchTerm;
            ReferenceJson = fileReferenceJson;
            CreatedDate = DateTime.Now;
        }

        public string SearchTerm { get; }

        public string ReferenceJson { get; }

        public DateTime CreatedDate { get; }
    }
}