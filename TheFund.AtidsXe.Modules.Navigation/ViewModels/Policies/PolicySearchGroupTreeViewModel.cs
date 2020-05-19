using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Ensure;
using JetBrains.Annotations;
using Prism.Events;
using ReactiveUI;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;
using TheFund.AtidsXe.Modules.WorkSpace.Services;
using DelegateCommand = Prism.Commands.DelegateCommand;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.Policies
{
    [Export(typeof(IPolicySearchGroupTreeViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class PolicySearchGroupTreeViewModel : ViewModelBase, IPolicySearchGroupTreeViewModel
    {
        #region Fields

        private readonly IWorkspaceService _workspaceService;
        private bool _isBusy;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public PolicySearchGroupTreeViewModel(IEventAggregator eventAggregator, IWorkspaceService workspaceService) :
                base(eventAggregator)
        {
            _workspaceService = workspaceService;
            Initialize();
        }

        #endregion

        #region Properties

        public ObservableCollection<IPolicySearchLegalTreeViewModel> PolicySearchLegalViewModels { get; set; }

        public bool IsEnabled => !_isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                this.RaisePropertyChanged();
                this.RaisePropertyChanged(nameof(IsEnabled));
            }
        }

        public IOutlookBarItemViewModel Parent { get; set; }

        public IFileReference FileReference { get; set; }

        #endregion

        #region Commands

        public DelegateCommand SelectPolicySearchGroupCommand { get; set; }

        private void OnSelectPolicySearchGroupExecute()
        {
        }

        private bool CanSelectPolicySearchGroupExecute()
        {
            return true;
        }

        public DelegateCommand EditSearchCommand { get; set; }

        private void OnEditSearch()
        {
            
        }

        private static bool CanEditSearch()
        {
            return true;
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            _isBusy = false;
            PolicySearchLegalViewModels = new ObservableCollection<IPolicySearchLegalTreeViewModel>();
            InitiialzeCommands();
        }

        private void InitiialzeCommands()
        {
            SelectPolicySearchGroupCommand = new DelegateCommand(OnSelectPolicySearchGroupExecute, CanSelectPolicySearchGroupExecute);
            EditSearchCommand = new DelegateCommand(OnEditSearch, CanEditSearch);
        }

        public void Build([NotNull] IFileReference fileReference, [NotNull] IOutlookBarItemViewModel parent)
        {
            fileReference.EnsureNotNull();
            parent.EnsureNotNull();

            FileReference = fileReference;
            Parent = parent;
        }

        #endregion
    }
}