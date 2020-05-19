using TheFund.AtidsXe.Modules.Search.Models;

namespace TheFund.AtidsXe.Modules.Search.Factories
{
    public static class RecentItemsFactory
    {
        public static IRecentSearchTerm Create(string item)
        {
            return new RecentSearchTerm
            {
                SearchTerm = item
            };
        }
    }
}