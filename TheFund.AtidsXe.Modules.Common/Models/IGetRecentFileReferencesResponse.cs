using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface IGetRecentFileReferencesResponse
    {
        int UserId { get; }
        IEnumerable<IFileReference> FileReferences { get; }
    }
}