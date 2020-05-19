using JetBrains.Annotations;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.WorkSpace.ViewModels;

namespace TheFund.AtidsXe.Modules.WorkSpace.Services
{
    [Export(typeof(IWorkspaceService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class WorkspaceService : IWorkspaceService
    {
        #region Fields

        private readonly IWorkspaceViewModel _workspaceViewModel;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public WorkspaceService(IWorkspaceViewModel workspaceViewModel)
        {
            _workspaceViewModel = workspaceViewModel;
        }

        #endregion

        #region Methods

        public int GetWorkspaceSelectedIndex()
        {
            return _workspaceViewModel.SelectedIdex;
        }

        public async Task ShowPropertySearchesView([NotNull] IFileReference fileReference)
        {
            await _workspaceViewModel.ShowPropertySearchesView(fileReference);
        }

        public async Task ShowPropertySearchLegalView([NotNull] IFileReference fileReference)
        {
            await _workspaceViewModel.ShowPropertySearchLegalView(fileReference);
        }

        public async Task ShowPropertySearchView([NotNull] (IFileReference fileReference, int searchId) args)
        {
            await _workspaceViewModel.ShowPropertySearchView(args);
        }

        public async Task ShowChainOfTitlesView([NotNull] IFileReference fileReference)
        {
            await _workspaceViewModel.ShowChainOfTitlesView(fileReference);
        }

        public async Task ShowChainOfTitleView([NotNull] (IFileReference fileReference, int chainOfTitleId, int searchId) args)
        {
            await _workspaceViewModel.ShowChainOfTitleView(args);
        }

        public async Task ShowWorksheetView([NotNull] IFileReference fileReference)
        {
            await _workspaceViewModel.ShowWorksheetView(fileReference);
        }

        #endregion
    }
}
