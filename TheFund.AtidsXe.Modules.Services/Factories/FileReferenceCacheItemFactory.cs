using TheFund.AtidsXe.Modules.Services.Models;

namespace TheFund.AtidsXe.Modules.Services.Factories
{
    public static class FileReferenceCacheItemFactory
    {
        public static IFileReferenceCacheItem Create(int fileReferenceId, string fileReferenceJson)
        {
            return new FileReferenceCacheItem(fileReferenceId, fileReferenceJson);
        }
    }
}