using Ensure;
using JetBrains.Annotations;
using Prism.Events;
using ReactiveUI;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;
using TheFund.AtidsXe.Modules.WorkSpace.Services;
using DelegateCommand = Prism.Commands.DelegateCommand;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.Names
{
    [Export(typeof(INameSearchGroupTreeViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class NameSearchGroupTreeViewModel : ViewModelBase, INameSearchGroupTreeViewModel
    {
        #region Fields

        private bool _isBusy;
        private readonly IWorkspaceService _workspaceService;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public NameSearchGroupTreeViewModel(IEventAggregator eventAggregator, IWorkspaceService workspaceService) : base(eventAggregator)
        {
            _workspaceService = workspaceService;
            Initialize();
        }

        #endregion

        #region Properties

        public IOutlookBarItemViewModel Parent { get; set; }

        public IFileReference FileReference { get; set; }

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

        public DelegateCommand SelectNameSearchGroupCommand { get; set; }

        private void OnSelectNameSearchGroup()
        {
        }

        private static bool CanSelectNameSearchGroup()
        {
            return true;
        }

        public DelegateCommand EditSearchCommand { get; set; }

        private static void OnEditSearch()
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
            InitializeCommands();
        }

        public void InitializeCommands()
        {
            SelectNameSearchGroupCommand = new DelegateCommand(OnSelectNameSearchGroup, CanSelectNameSearchGroup);
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