using System.Collections.ObjectModel;
using Prism.Commands;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;
using TheFund.AtidsXe.Modules.WorkSpace.Services;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.ChainOfTitles
{
    public interface IChainOfTitleGroupTreeViewModel : INavigationGroupTreeViewModel
    {
        ObservableCollection<IChainOfTitleTreeViewModel> ChainOfTitleViewModels { get; }
        IFileReference FileReference { get; }
        int ChainOfTitlesCount { get; set; }
        bool IsHidden { get; }
        DelegateCommand SortByLotAscendingCommand { get; set; }
        DelegateCommand SelectChainOfTitlesCommand { get; set; }
        DelegateCommand ReplaceAllCommand { get; set; }
        bool IsBusy { get; set; }
        bool IsEnabled { get; }
        IOutlookBarItemViewModel Parent { get; set; }
        void SetProgressIndicatorOn();
        void SetProgressIndicatorOff();
    }
}