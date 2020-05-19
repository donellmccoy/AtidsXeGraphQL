namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface IDeleteRecentFileReferencesRequest
    {
        int UserId { get; }
        int[] FileReferenceIds { get; }
    }
}