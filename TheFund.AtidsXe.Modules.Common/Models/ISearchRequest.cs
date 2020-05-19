namespace TheFund.AtidsXe.Modules.Common.Models
{
    public interface ISearchRequest : IRequest
    {
        string SearchTerm { get; }
    }
}