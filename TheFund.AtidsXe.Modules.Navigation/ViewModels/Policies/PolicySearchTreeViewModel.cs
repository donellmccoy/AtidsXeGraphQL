using System.ComponentModel.Composition;
using Prism.Commands;
using Prism.Events;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.WorkSpace.Services;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.Policies
{
    [Export(typeof(IPolicySearchTreeViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class PolicySearchTreeViewModel : ViewModelBase, IPolicySearchTreeViewModel
    {
        #region Constructors

        [ImportingConstructor]
        public PolicySearchTreeViewModel(IEventAggregator eventAggregator, IWorkspaceService workspaceService) :
                base(eventAggregator)
        {
            WorkspaceService = workspaceService;
            Initialize();
        }

        #endregion

        #region Properties

        public IWorkspaceService WorkspaceService { get; }

        #endregion

        #region Commands

        public DelegateCommand EditSearchCommand { get; set; }

        private static void OnEditSearchExecute()
        {

        }

        private static bool CanEditSearchExecute()
        {
            return true;
        }

        public DelegateCommand HideSearchCommand { get; set; }

        private static void OnHideSearchExecute()
        {

        }

        private bool CanHideSearchExecute()
        {
            return true;
        }

        public DelegateCommand UnhideSearchCommand { get; set; }

        private static void OnUnhideSearchExecute()
        {

        }

        private bool CanUnhideSearchExecute()
        {
            return true;
        }

        public DelegateCommand ViewSearchParametersCommand { get; set; }

        private static void OnViewSearchParametersExecute()
        {

        }

        private static bool CanViewSearchParametersExecute()
        {
            return true;
        }

        public DelegateCommand ViewSearchNotesCommand { get; set; }

        private static void OnViewSearchNotesExecute()
        {

        }

        private static bool CanViewSearchNotesExecute()
        {
            return true;
        }

        public DelegateCommand CreateChainOfTitleCommand { get; set; }

        private static void OnCreateChainOfTitleExecute()
        {

        }

        private bool CanCreateChainOfTitleExecute()
        {
            return false;
        }

        public DelegateCommand ReplaceChainOfTitleCommand { get; set; }

        private static void OnReplaceChainOfTitleExecute()
        {

        }

        private bool CanReplaceChainOfTitleExecute()
        {
            return true;
        }

        public DelegateCommand ShareWithUserCommand { get; set; }

        private static void OnShareWithUserExecute()
        {

        }

        private bool CanShareWithUserExecute()
        {
            return true;
        }

        public DelegateCommand ShowPropertyOnMapCommand { get; set; }

        private static void OnShowPropertyOnMapExecute()
        {

        }

        private bool CanShowPropertyOnMapExecute()
        {
            return true;
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            InitiialzeCommands();
        }

        private void InitiialzeCommands()
        {

        }

        #endregion
    }
}