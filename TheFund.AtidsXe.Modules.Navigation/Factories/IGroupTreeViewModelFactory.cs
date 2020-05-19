using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Navigation.ViewModels;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;

namespace TheFund.AtidsXe.Modules.Navigation.Factories
{
    public interface IGroupTreeViewModelFactory
    {
        T Create<T>(IFileReference fileReference, IOutlookBarItemViewModel parent) where T : INavigationGroupTreeViewModel;
    }
}
