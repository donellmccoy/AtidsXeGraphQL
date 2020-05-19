using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.WorkSpace.ViewModels
{
    public interface IWorkspaceViewModel
    {
        ObservableCollection<ITitleEventViewModel> TitleEventViewModels { get; set; }
        ObservableCollection<IWorksheetViewModel> WorksheetViewModels { get; set; }
        ObservableCollection<IChainOfTitleViewModel> ChainOfTitleViewModels { get; set; }
        ITitleEventViewModel SelectedTitleEventViewModel { get; set; }
        IWorksheetViewModel SelectedWorksheetViewModel { get; set; }
        IChainOfTitleViewModel SelectedChainOfTitleViewModel { get; set; }
        int SelectedIdex { get; set; }
        Task ShowChainOfTitleView((IFileReference fileReference, int chainOfTitleId, int searchId) args);
        Task ShowPropertySearchView((IFileReference fileReference, int searchId) args);
        Task ShowWorksheetView(IFileReference fileReference);
        Task ShowChainOfTitlesView(IFileReference fileReference);
        Task ShowPropertySearchesView(IFileReference fileReference);
        Task ShowPropertySearchLegalView(IFileReference fileReference);
    }
}