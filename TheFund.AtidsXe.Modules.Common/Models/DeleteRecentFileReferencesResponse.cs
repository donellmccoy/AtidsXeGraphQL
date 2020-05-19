using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public sealed class DeleteRecentFileReferencesResponse : IDeleteRecentFileReferencesResponse
    {
        public int UserId { get; }
        public IEnumerable<IFileReference> FileReferences { get; }

        public DeleteRecentFileReferencesResponse(int userId, params IFileReference[] fileReferences)
        {
            UserId = userId;
            FileReferences = fileReferences;
        }
    }
}