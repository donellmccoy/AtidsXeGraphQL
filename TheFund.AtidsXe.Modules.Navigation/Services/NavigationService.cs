using System.ComponentModel.Composition;
using JetBrains.Annotations;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;

namespace TheFund.AtidsXe.Modules.Navigation.Services
{
    [Export(typeof(INavigationService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    internal class NavigationService : INavigationService
    {
        private readonly IOutlookBarViewModel _outlookBarViewModel;

        [ImportingConstructor]
        public NavigationService(IOutlookBarViewModel outlookBarViewModel)
        {
            _outlookBarViewModel = outlookBarViewModel;
        }

        public void LoadFileReference([NotNull] IFileReference fileReference)
        {
            _outlookBarViewModel.LoadFileReference(fileReference);
        }

        public void UnloadFileReference(int fileReferenceId)
        {
            //_outlookBarViewModel.UnloadFileReference(fileReferenceId);
        }
    }
}
