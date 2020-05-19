using JetBrains.Annotations;
using Prism.Events;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.Navigation.Enumerations;
using TheFund.AtidsXe.Modules.Navigation.Models;
using TheFund.AtidsXe.Modules.WorkSpace.Services;
using DelegateCommand = Prism.Commands.DelegateCommand;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.ChainOfTitles
{
    [Export(typeof(IChainOfTitleTreeViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class ChainOfTitleTreeViewModel : ViewModelBase, IChainOfTitleTreeViewModel
    {
        #region Fields

        private bool _isBusy;
        private ChainOfTitleType _chainOfTitleType;
        private bool _isHidden;
        private string _legalName;
        private string _searchRange;
        private int _reviewNeeded;
        private bool _isDirty = true;
        private bool _isInWorkspace;
        private bool _isCombinedChainOfTitle;
        private bool _isSelected;
        private readonly IWorkspaceService _workspaceService;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public ChainOfTitleTreeViewModel(IEventAggregator eventAggregator, IWorkspaceService workspaceService) : base(eventAggregator)
        {
            _workspaceService = workspaceService;
            Initialize();
        }

        #endregion

        #region Properties

        public IChainOfTitleGroupTreeViewModel Parent { get; set; }

        public ChainOfTitleType ChainOfTitleType
        {
            get => _chainOfTitleType;
            set
            {
                _chainOfTitleType = value;
                this.RaisePropertyChanged();
            }
        }

        public IFileReference FileReference => Parent.FileReference;

        public int ChainOfTitleId { get; set; }

        public int SearchId { get; set; }

        public bool IsInWorkspace
        {
            get => _isInWorkspace;
            set
            {
                _isInWorkspace = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsDirty
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsHidden
        {
            get => _isHidden;
            set
            {
                _isHidden = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsCombinedChainOfTitle
        {
            get => _isCombinedChainOfTitle;
            set
            {
                _isCombinedChainOfTitle = value;
                this.RaisePropertyChanged();
            }
        }

        public string LegalName
        {
            get => _legalName;
            set
            {
                _legalName = value;
                this.RaisePropertyChanged();
            }
        }

        public string SearchRange
        {
            get => _searchRange;
            set
            {
                _searchRange = value;
                this.RaisePropertyChanged();
            }
        }

        public int ReviewNeeded
        {
            get => _reviewNeeded;
            set
            {
                _reviewNeeded = value;
                this.RaisePropertyChanged();
            }
        }

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

        public bool IsEnabled => !_isBusy;

        public ObservableCollection<SelectableViewModel> Items1 { get; set; }

        #endregion

        #region Commands

        public DelegateCommand SelectChainOfTitleCommand { get; set; }

        private void OnSelectChainOfTitle()
        {
            _workspaceService.ShowChainOfTitleView((FileReference, ChainOfTitleId, SearchId));
        }

        private bool CanSelectChainOfTitle()
        {
            return !IsBusy && _workspaceService.GetWorkspaceSelectedIndex() != 2;
        }

        public DelegateCommand EditChainOfTitleSearchCommand { get; set; }

        private async void OnEditChainOfTitleSearch()
        {
            await Task.Delay(1000);
        }

        private bool CanEditChainOfTitleSearch()
        {
            return !IsBusy;
        }

        public DelegateCommand RegenerateCommand { get; set; }

        private async void OnRegenerate()
        {
            Parent.SetProgressIndicatorOn();

            SetProgressIndicatorOn();
            await Task.Delay(3000);
            SetProgressIndicatorOff();

            ReviewNeeded = 8;
            IsCombinedChainOfTitle = false;

            RegenerateCommand.RaiseCanExecuteChanged();
            EditChainOfTitleSearchCommand.RaiseCanExecuteChanged();
            SelectChainOfTitleCommand.RaiseCanExecuteChanged();

            Parent.SetProgressIndicatorOff();
        }

        private bool CanRegenerate()
        {
            return !IsBusy;
        }

        public DelegateCommand AddToWorkspaceCommand { get; set; }

        private void OnAddToWorkspace()
        {
        }

        private bool CanAddToWorkspace()
        {
            return !_isInWorkspace;
        }

        public DelegateCommand RemoveFromWorkspaceCommand { get; set; }

        private void OnRemoveFromWorkspace()
        {
        }

        private bool CanRemoveFromWorkspace()
        {
            return _isInWorkspace;
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            Items1 = new ObservableCollection<SelectableViewModel>();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            SelectChainOfTitleCommand = new DelegateCommand(OnSelectChainOfTitle, CanSelectChainOfTitle);
            EditChainOfTitleSearchCommand = new DelegateCommand(OnEditChainOfTitleSearch, CanEditChainOfTitleSearch);
            RegenerateCommand = new DelegateCommand(OnRegenerate, CanRegenerate);
            AddToWorkspaceCommand = new DelegateCommand(OnAddToWorkspace, CanAddToWorkspace);
            RemoveFromWorkspaceCommand = new DelegateCommand(OnRemoveFromWorkspace, CanRemoveFromWorkspace);
        }

        public void SetProgressIndicatorOn()
        {
            IsBusy = true;
        }

        public void SetProgressIndicatorOff()
        {
            IsBusy = false;
        }

        public void Build([NotNull] IChainOfTitle chainOfTitle, [NotNull] IFileReference fileReference, [NotNull] IChainOfTitleGroupTreeViewModel parent)
        {
            ChainOfTitleId = chainOfTitle.ChainOfTitleId;
            Parent = parent;

            var chainOfTitleSearch = chainOfTitle.GetChainOfTitleSearch(chainOfTitle.ChainOfTitleId);

            _legalName = CreateLegalName(chainOfTitleSearch);
            _searchRange = GetSearchRange(chainOfTitleSearch);
            _reviewNeeded = GetReviewNeededCount(chainOfTitle);
            _isCombinedChainOfTitle = GetIsCombinedChainOfTitle(chainOfTitle);
        }

        private static string GetSearchRange([NotNull] ChainOfTitleSearch chainOfTitleSearch)
        {
            return chainOfTitleSearch != null ?
                $"{chainOfTitleSearch.Search.SearchFromDate:MM/dd/yyyy} - {chainOfTitleSearch.Search.SearchThruDate:MM/dd/yyyy}" :
                "[ Search Range ]";
        }

        private static bool GetIsCombinedChainOfTitle([NotNull] IChainOfTitle chainOfTitle)
        {
            return true;
        }

        private static int GetReviewNeededCount([NotNull] IChainOfTitle chainOfTitle)
        {
            return 5;
        }

        private static string CreateLegalName([NotNull] ChainOfTitleSearch chainOfTitleSearch)
        {
            return chainOfTitleSearch != null ? "13 PB (22/15)" : "[ Legal Name ]";
        }

        #endregion
    }
}