using System.Collections.ObjectModel;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Enumerations.Search;
using TheFund.AtidsXe.Modules.WorkSpace.Services;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.Properties
{
    public interface IPropertySearchLegalTreeViewModel
    {
        void Build(IFileReference fileReference, ISearch search, IPropertySearchGroupTreeViewModel parent);
        ObservableCollection<IPropertySearchTreeViewModel> PropertySearchViewModels { get; set; }
        int FileReferenceId { get; set; }
        int SearchId { get; set; }
        SearchType SearchType { get; set; }
        string Color { get; }
        PackIconKind Icon { get; set; }
        string LegalName { get; set; }
        IFileReference FileReference { get; set; }
        IPropertySearchGroupTreeViewModel Parent { get; set; }
        IWorkspaceService WorkspaceService { get; }
        bool IsEnabled { get; }
        bool IsBusy { get; set; }
        DelegateCommand SelectPropertySearchLegalCommand { get; set; }
        DelegateCommand EditSearchCommand { get; set; }
        DelegateCommand ViewSearchParametersCommand { get; set; }
        DelegateCommand ViewSearchNotesCommand { get; set; }
        DelegateCommand ShareWithUserCommand { get; set; }
        DelegateCommand ShowPropertyOnMapCommand { get; set; }
    }
}