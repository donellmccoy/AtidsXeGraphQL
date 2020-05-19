using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;

namespace TheFund.AtidsXe.Modules.Navigation.Factories
{
    public interface IOutlookBarItemViewModelFactory
    {
        T Create<T>(IFileReference fileReference, IOutlookBarViewModel parent)
            where T : IOutlookBarItemViewModel;
    }
}
