namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface ICreateUserFavoriteRequest
    {
        int UserId { get; }
        int[] FileReferenceIds { get; }
    }
}