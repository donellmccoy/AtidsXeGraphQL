using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.Services.Factories
{
    public static class FileReferenceResponseFactory
    {
        public static IFileReferenceResponse CreateFileReferenceResponse(IFileReference fileReference)
        {
            return new FileReferenceResponse(fileReference);
        }
    }
}