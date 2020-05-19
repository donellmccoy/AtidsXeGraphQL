using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface ISearchResponse
    {
        IEnumerable<IFileReference> FileReferences { get; }
    }

}