namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface IGetUserFavoritesRequest
    {
        int UserId { get; }
        string CacheRegion { get; }
        string CacheKey { get; }
    }
}