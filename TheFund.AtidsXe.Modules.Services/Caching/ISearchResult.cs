namespace TheFund.AtidsXe.Modules.Services.Caching
{
    public interface ISearchResult
    {
        string JsonResult { get; }
        string SearchTerm { get; }
    }
}
