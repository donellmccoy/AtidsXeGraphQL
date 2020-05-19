using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface ICreateRecentFileReferencesResponse
    {
        int UserId { get; }
        IFileReference[] FileReferences { get; }
    }
}