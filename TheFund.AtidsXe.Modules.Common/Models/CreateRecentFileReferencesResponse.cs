using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public sealed class CreateRecentFileReferencesResponse : ICreateRecentFileReferencesResponse
    {
        public int UserId { get; }
        public IFileReference[] FileReferences { get; }

        public CreateRecentFileReferencesResponse(int userId, params IFileReference[] fileReferences)
        {
            UserId = userId;
            FileReferences = fileReferences;
        }
    }
}