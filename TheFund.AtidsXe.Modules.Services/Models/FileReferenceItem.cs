using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Services.Models
{
    public sealed class FileReferenceItem : IFileReferenceItem
    {
        public FileReferenceItem(IFileReference fileReference)
        {
            FileReferenceReference = fileReference;
        }

        public IFileReference FileReferenceReference { get; }
    }
}