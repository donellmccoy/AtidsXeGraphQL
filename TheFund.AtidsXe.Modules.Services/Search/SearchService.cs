using DynamicData;
using DynamicData.Kernel;
using Ensure;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.Constants;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Extensions;
using TheFund.AtidsXe.Modules.Common.Factories;
using TheFund.AtidsXe.Modules.Common.Models;
using TheFund.AtidsXe.Modules.Services.Caching;
using TheFund.AtidsXe.Modules.Services.Factories;
using TheFund.AtidsXe.Modules.Services.GraphQL;

namespace TheFund.AtidsXe.Modules.Services.Search
{
    [Export(typeof(ISearchService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class SearchService : ISearchService
    {
        #region Fields

        private readonly IGraphQLService _graphQLService;
        private readonly ICachingService _cachingService;
        private readonly ISearchResultCollection _searchResultCollection;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public SearchService(
            IGraphQLService graphQlService, 
            ICachingService cachingService, 
            ISearchResultCollection searchResultCollection)
        {
            _graphQLService = graphQlService;
            _cachingService = cachingService;
            _searchResultCollection = searchResultCollection;
        }

        #endregion

        public SourceList<string> SearchResults { get; set; }

        public IObservable<int> Count => _searchResultCollection.Connect().DeferUntilLoaded().Count();

        #region Methods

        public IObservable<IEnumerable<IFileReference>> SearchFileReferences(string searchTerm, CancellationToken token)
        {
            return Observable.Defer<IEnumerable<IFileReference>>(async () =>
            {
                var searchResult = await _searchResultCollection.AddOrUpdate
                (
                    searchTerm,
                    () => _graphQLService.GetFileReferencesAsync(searchTerm, token)
                );

                var fileReferences = FileReferencesFactory.Create(searchResult.JsonResult);

                return Observable.Return<IEnumerable<IFileReference>>(fileReferences);
            });
        }

        public async Task<ImmutableList<IFileReference>> SearchFileReferencesAsync(string searchTerm, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return ImmutableList<IFileReference>.Empty;
            }

            var searchResult = await _searchResultCollection.AddOrUpdate
            (
                searchTerm, 
                () => _graphQLService.GetFileReferencesAsync(searchTerm, token)
            );

            return FileReferencesFactory.Create(searchResult.JsonResult);
        }

        public async Task<IFileReferenceResponse> GetFileReferenceAsync(IFileReferenceRequest request, CancellationToken token)
        {
            request.EnsureNotNull();

            return FileReferenceResponseFactory.CreateFileReferenceResponse
            (
                FileReferenceFactory.Create
                (
                    await _cachingService.AddOrGetExistingAsync
                    (
                        request.FileReferenceId,
                        request.CacheRegion,
                        () => _graphQLService.GetFileReferenceAsync(request.FileReferenceId, token)
                    )
                )
            );
        }

        #endregion
	}
}
