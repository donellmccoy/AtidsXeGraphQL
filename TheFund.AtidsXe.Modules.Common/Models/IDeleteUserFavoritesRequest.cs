namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface IDeleteUserFavoritesRequest : IRequest
    {
        int UserId { get; }
        int[] FileReferences { get; }
        string CacheKey { get; }
    }
}