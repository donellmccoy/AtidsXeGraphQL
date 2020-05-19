using Microsoft.Practices.ServiceLocation;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using TheFund.AtidsXe.Modules.Common.Constants;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Search.Models;
using TheFund.AtidsXe.Modules.Search.ViewModels;
using TheFund.AtidsXe.Modules.Services.Caching;

namespace TheFund.AtidsXe.Modules.Search.Factories
{
    public static class SearchViewModelListItemFactory
    {
        private static readonly IFileReferenceCachingService _cachingService;

        static SearchViewModelListItemFactory()
        {
            _cachingService = ServiceLocator.Current.GetInstance<IFileReferenceCachingService>();
        }

        public static IEnumerable<IFileReferenceListItemViewModel> Create(ImmutableList<IFileReference> fileReferences, ISearchViewModel parent)
        {
            return fileReferences.Select(fileReference => Create(fileReference, _cachingService.IsCached(fileReference.FileReferenceId), parent));
        }

        private static IFileReferenceListItemViewModel Create(IFileReference fileReference, bool isOpened, ISearchViewModel parent = null)
        {
            var model = new FileReferenceListItemViewModel
            {
                FileReferenceId = fileReference.FileReferenceId,
                FileReferenceName = fileReference.FileReferenceName,
                WorkerId = fileReference.WorkerId,
                CreatedDate = fileReference.CreateDate,
                UpdateDate = fileReference.UpdateDate,
                IsTemporaryFile = fileReference.IsTemporaryFileBool,
                FileStatus = fileReference.FileStatus,
                HasChainOfTitles = fileReference.HasChainOfTitles,
                ChainOfTitlesCount = fileReference.ChainOfTitlesCount,
                PropertySearchesCount = fileReference.PropertySearchesCount,
                PolicySearchesCount = fileReference.PolicySearchesCount,
                NameSearchesCount = fileReference.NameSearchesCount,
                BranchLocation = fileReference.BranchLocation,
                Parent = parent,
                FileReference = fileReference
            };

            return model;
        }
    }
}