using TheFund.AtidsXe.Modules.Common.Constants;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public sealed class FileReferenceRequest : IFileReferenceRequest
    {
        public FileReferenceRequest(int fileReferenceId)
        {
            FileReferenceId = fileReferenceId;
        }

        public int FileReferenceId { get; }
        public string CacheRegion => CacheRegions.FileReferences;
    }
}