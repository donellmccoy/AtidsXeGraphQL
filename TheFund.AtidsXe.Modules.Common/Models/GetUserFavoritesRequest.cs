namespace TheFund.AtidsXe.Modules.Common.Models
{
    public sealed class GetUserFavoritesRequest : IGetUserFavoritesRequest
    {
        public int UserId { get; }
        public string CacheRegion { get; }
        public string CacheKey { get; }

        public GetUserFavoritesRequest(int userId)
        {
            UserId = userId;
            CacheKey = $"{userId}";
            CacheRegion = "UserFavorites";
        }
    }
}