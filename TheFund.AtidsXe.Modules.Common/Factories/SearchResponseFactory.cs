using System.Collections.Generic;
using JetBrains.Annotations;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Common.Factories
{
    [UsedImplicitly]
    public class SearchResponseFactory
    {
        public static ISearchResponse Create([NotNull] IEnumerable<IFileReference> fileReferences)
        {
            return new SearchResponse(fileReferences);
        }
    }
}