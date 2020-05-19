using System.ComponentModel.Composition;

namespace TheFund.AtidsXe.Modules.Search.Models
{
    [Export(typeof(IUserFavoriteViewModelListItem))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class UserFavoriteViewModelListItem : IUserFavoriteViewModelListItem
    {

    }
}