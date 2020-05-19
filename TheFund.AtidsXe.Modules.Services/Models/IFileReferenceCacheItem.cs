namespace TheFund.AtidsXe.Modules.Services.Models
{
    public interface IFileReferenceCacheItem : ICacheItem
    {
        int FileReferenceId { get; }
    }
}