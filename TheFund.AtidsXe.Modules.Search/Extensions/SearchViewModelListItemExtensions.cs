using TheFund.AtidsXe.Modules.Search.Models;

namespace TheFund.AtidsXe.Modules.Search.Extensions
{
    public static class SearchViewModelListItemExtensions
    {
        public static bool IsSelected(this IFileReferenceListItemViewModel item)
        {
            return item?.IsOpened ?? false;
        }
    }
}
