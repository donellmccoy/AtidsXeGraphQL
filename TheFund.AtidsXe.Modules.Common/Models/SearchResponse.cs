using System.Collections.Generic;
using System.Linq;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public sealed class SearchResponse : ISearchResponse
    {
        public SearchResponse(IEnumerable<IFileReference> fileReferences)
        {
            FileReferences = fileReferences ?? Enumerable.Empty<IFileReference>();
        }

        public IEnumerable<IFileReference> FileReferences { get; }
    }

}