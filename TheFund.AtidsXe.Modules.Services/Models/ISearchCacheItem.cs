namespace TheFund.AtidsXe.Modules.Services.Models
{
    public interface ISearchCacheItem : ICacheItem
    {
        string SearchTerm { get; }
    }
}