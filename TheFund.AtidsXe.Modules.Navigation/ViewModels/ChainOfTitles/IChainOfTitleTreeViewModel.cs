using Prism.Commands;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Navigation.Enumerations;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.ChainOfTitles
{
    public interface IChainOfTitleTreeViewModel
    {
        IChainOfTitleGroupTreeViewModel Parent { get; }
        ChainOfTitleType ChainOfTitleType { get; set; }
        IFileReference FileReference { get; }
        int ChainOfTitleId { get; }
        int SearchId { get; }
        bool IsInWorkspace { get; set; }
        bool IsDirty { get; set; }
        bool IsHidden { get; set; }
        bool IsSelected { get; set; }
        bool IsCombinedChainOfTitle { get; set; }
        string LegalName { get; set; }
        string SearchRange { get; set; }
        int ReviewNeeded { get; set; }
        bool IsBusy { get; set; }
        bool IsEnabled { get; }
        DelegateCommand SelectChainOfTitleCommand { get; set; }
        DelegateCommand EditChainOfTitleSearchCommand { get; set; }
        DelegateCommand RegenerateCommand { get; set; }
        DelegateCommand AddToWorkspaceCommand { get; set; }
        DelegateCommand RemoveFromWorkspaceCommand { get; set; }
        void SetProgressIndicatorOn();
        void SetProgressIndicatorOff();
        void Build(IChainOfTitle chainOfTitle, IFileReference fileReference, IChainOfTitleGroupTreeViewModel parent);
    }
}