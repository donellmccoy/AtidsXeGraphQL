using DynamicData;
using Ensure;
using ReactiveUI;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.Constants;
using TheFund.AtidsXe.Modules.Services.Caching;

namespace TheFund.AtidsXe.Modules.Services.RecentItems
{
    [Export(typeof(IRecentSearchesService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class RecentSearchesService : IRecentSearchesService
    {
        #region Fields

        private readonly ICachingService _cachingService;
        private readonly SourceList<string> _recentSearchTerms = new SourceList<string>();

        #endregion

        #region Constructors

        [ImportingConstructor]
        public RecentSearchesService(ICachingService cachingService)
        {
            _cachingService = cachingService;
        }

        #endregion

        #region Properties

        public IObservableList<string> RecentSearchTerms => _recentSearchTerms;

        #endregion

        #region Methods

        public IObservable<IChangeSet<string>> Connect()
        {
            return _recentSearchTerms.Connect().SubscribeOn(RxApp.TaskpoolScheduler);
        }

        public Task<string> AddSearchTermAsync(string searchTerm, CancellationToken token = default)
        {
            return Task.Run(() => 
            {
                searchTerm.EnsureNotNullOrWhitespace();

                if (_recentSearchTerms.Items.Count() > 4)
                {
                    var lastTerm = _recentSearchTerms.Items.Last();
                    _recentSearchTerms.Remove(lastTerm);
                    _cachingService.Remove(lastTerm, CacheRegions.SearchTerms);
                }

                if (!_recentSearchTerms.Items.Contains(searchTerm))
                {
                    _recentSearchTerms.Insert(0, searchTerm);
                }

                return searchTerm;
            }, token);
        }

        public string AddSearchTerm(string searchTerm)
        {
            searchTerm.EnsureNotNullOrWhitespace();

            if (_recentSearchTerms.Items.Count() > 4)
            {
                var lastTerm = _recentSearchTerms.Items.Last();
                _recentSearchTerms.Remove(lastTerm);
                _cachingService.Remove(lastTerm, CacheRegions.SearchTerms);
            }

            if (!_recentSearchTerms.Items.Contains(searchTerm))
            {
                _recentSearchTerms.Insert(0, searchTerm);
            }

            return searchTerm;
        }

        #endregion
    }
}