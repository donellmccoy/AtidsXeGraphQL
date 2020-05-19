using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels
{
    public interface INavigationGroupTreeViewModel
    {
        void Build(IFileReference fileReference, IOutlookBarItemViewModel parent);
    }
}