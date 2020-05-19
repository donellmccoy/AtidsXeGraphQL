using DynamicData;
using DynamicData.Kernel;
using System;
using System.ComponentModel.Composition;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Optional;
using System.Linq;

namespace TheFund.AtidsXe.Modules.Services.Caching
{
    [Export(typeof(ISearchResultCollection))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class SearchResultCollection : ISearchResultCollection, IDisposable
    {
        private readonly IDisposable _cleanUp;
        private readonly SourceCache<SearchInfo, string> _cache;

        public IObservableList<SearchInfo> Items => Connect().AsObservableList();

        public SearchResultCollection()
        {
            _cache = new SourceCache<SearchInfo, string>(searchInfo => searchInfo.SearchTerm);

            _cleanUp = new CompositeDisposable(_cache);
        }

        public IObservable<IChangeSet<SearchInfo>> Connect()
        {
            return _cache.Connect().RemoveKey();
        }

        public IObservable<Change<SearchInfo, string>> Watch(string key)
        {
            return _cache.Watch(key);
        }

        public SearchInfo Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("message", nameof(key));
            }

            var optional = _cache.Lookup(key);

            return optional.HasValue ? optional.Value : null;
        }

        public async Task<SearchInfo> AddOrUpdate(string key, Func<Task<string>> valueFactory)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("message", nameof(key));
            }

            if (valueFactory is null)
            {
                throw new ArgumentNullException(nameof(valueFactory));
            }

            var searchInfo = Get(key);

            string jsonResult;

            if (searchInfo is null)
            {
                jsonResult = await valueFactory();
                searchInfo = new SearchInfo(key, jsonResult);
                if (!string.IsNullOrWhiteSpace(jsonResult))
                {
                    Add(searchInfo);
                }
            }

            return searchInfo;
        }

        public void Add(SearchInfo searchResult)
        {
            if (searchResult is null)
            {
                throw new ArgumentNullException(nameof(searchResult));
            }
           
            _cache.AddOrUpdate(searchResult, SearchInfo.DefaultComparer);
        }

        public void RemoveKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("message", nameof(key));
            }

            _cache.RemoveKey(key);
        }

        public void Remove(SearchInfo searchResult)
        {
            if (searchResult is null)
            {
                throw new ArgumentNullException(nameof(searchResult));
            }

            _cache.Remove(searchResult);
        }

        public void Dispose()
        {
            _cleanUp.Dispose();
        }
    }
}
