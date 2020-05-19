using System;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Enumerations.Search;
using TheFund.AtidsXe.Modules.WorkSpace.Services;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.Properties
{
    public interface IPropertySearchTreeViewModel
    {
        void Build(IFileReference fileReference, ISearch search, IPropertySearchLegalTreeViewModel parent);
        int FileReferenceId { get; set; }
        int SearchId { get; set; }
        SearchType SearchType { get; set; }
        bool IsOnChainOfTitle { get; set; }
        bool IsHidden { get; set; }
        string DateRange { get; }
        DateTime SearchFromDate { get; set; }
        DateTime SearchThruDate { get; set; }
        string Color { get; }
        PackIconKind Icon { get; set; }
        string LegalName { get; }
        string InfoIconToolTip { get; }
        bool IsContentVisible { get; set; }
        bool IsBusy { get; set; }
        bool IsEnabled { get; }
        IWorkspaceService WorkspaceService { get; }
        DelegateCommand SelectPropertySearchCommand { get; set; }
        DelegateCommand EditSearchCommand { get; set; }
        DelegateCommand HideSearchCommand { get; set; }
        DelegateCommand UnhideSearchCommand { get; set; }
        DelegateCommand ViewSearchParametersCommand { get; set; }
        DelegateCommand ViewSearchNotesCommand { get; set; }
        DelegateCommand CreateChainOfTitleCommand { get; set; }
        DelegateCommand ReplaceChainOfTitleCommand { get; set; }
        DelegateCommand ShareWithUserCommand { get; set; }
        DelegateCommand ShowPropertyOnMapCommand { get; set; }
    }
}