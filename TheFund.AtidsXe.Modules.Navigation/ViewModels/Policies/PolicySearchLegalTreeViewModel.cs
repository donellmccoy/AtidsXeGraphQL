using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Prism.Events;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.WorkSpace.Services;
using DelegateCommand = Prism.Commands.DelegateCommand;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.Policies
{
    [Export(typeof(IPolicySearchLegalTreeViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class PolicySearchLegalTreeViewModel : ViewModelBase, IPolicySearchLegalTreeViewModel
    {
        #region Constructors

        [ImportingConstructor]
        public PolicySearchLegalTreeViewModel(IEventAggregator eventAggregator, IWorkspaceService workspaceService) :
                base(eventAggregator)
        {
            Initialize();
            WorkspaceService = workspaceService;
        }

        #endregion

        #region Properties

        public ObservableCollection<IPolicySearchTreeViewModel> PolicySearchViewModels { get; set; }

        public IWorkspaceService WorkspaceService { get; }

        #endregion

        #region Commands

        public DelegateCommand SelectPolicySearchLegalCommand { get; set; }

        private void OnSelectPolicySearchLegalExecute()
        {
        }

        private bool CanSelectPolicySearchLegalExecute()
        {
            return true;
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            PolicySearchViewModels = new ObservableCollection<IPolicySearchTreeViewModel>();
            InitiialzeCommands();
        }

        private void InitiialzeCommands()
        {
            SelectPolicySearchLegalCommand = new DelegateCommand(OnSelectPolicySearchLegalExecute, CanSelectPolicySearchLegalExecute);
        }

        #endregion
    }
}