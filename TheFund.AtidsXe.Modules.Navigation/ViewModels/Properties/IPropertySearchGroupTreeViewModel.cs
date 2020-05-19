using Prism.Commands;
using System.Collections.ObjectModel;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.Properties
{
    public interface IPropertySearchGroupTreeViewModel : INavigationGroupTreeViewModel
    {
        ObservableCollection<IPropertySearchLegalTreeViewModel> PropertySearchLegalViewModels { get; set; }
        bool IsEnabled { get; }
        bool IsBusy { get; set; }
        IOutlookBarItemViewModel Parent { get; set; }
        IFileReference FileReference { get; set; }
        DelegateCommand SelectPropertySearchGroupCommand { get; set; }
        DelegateCommand EditSearchCommand { get; set; }
        DelegateCommand ViewSearchParametersCommand { get; set; }
        DelegateCommand ViewSearchNotesCommand { get; set; }
        DelegateCommand ShareWithUserCommand { get; set; }
        DelegateCommand ShowPropertyOnMapCommand { get; set; }
    }
}