using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    public sealed class FileReferenceResponse : IFileReferenceResponse
    {
        public FileReferenceResponse(IFileReference fileReference)
        {
            FileReference = fileReference;
        }

        public IFileReference FileReference { get; }
    }

}