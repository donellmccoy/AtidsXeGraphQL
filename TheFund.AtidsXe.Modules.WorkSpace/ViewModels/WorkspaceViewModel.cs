using Prism.Events;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Events;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.Services.Caching;

namespace TheFund.AtidsXe.Modules.WorkSpace.ViewModels
{
    [Export(typeof(IWorkspaceViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class WorkspaceViewModel : ViewModelBase, IWorkspaceViewModel
    {
        #region Fields

        private readonly ICachingServiceV3 _cachingService;
        private int _selectedIdex;
        private IWorksheetViewModel _selectedWorksheetViewModel;
        private IChainOfTitleViewModel _selectedChainOfTitleViewModel;
        private ITitleEventViewModel _selectedTitleEventViewModel;
        private bool _isBusy;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public WorkspaceViewModel(IEventAggregator eventAggregator, ICachingServiceV3 cachingService) : base(eventAggregator)
        {
            _cachingService = cachingService;
            Iniitialize();
        }

        #endregion

        #region Properties

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<ITitleEventViewModel> TitleEventViewModels { get; set; }

        public ITitleEventViewModel SelectedTitleEventViewModel
        {
            get => _selectedTitleEventViewModel;
            set
            {
                _selectedTitleEventViewModel = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<IWorksheetViewModel> WorksheetViewModels { get; set; }

        public IWorksheetViewModel SelectedWorksheetViewModel
        {
            get => _selectedWorksheetViewModel;
            set
            {
                _selectedWorksheetViewModel = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<IChainOfTitleViewModel> ChainOfTitleViewModels { get; set; }

        public IChainOfTitleViewModel SelectedChainOfTitleViewModel
        {
            get => _selectedChainOfTitleViewModel;
            set
            {
                _selectedChainOfTitleViewModel = value;
                this.RaisePropertyChanged();
            }
        }

        public int SelectedIdex
        {
            get => _selectedIdex;
            set
            {
                _selectedIdex = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Methods

        private void Iniitialize()
        {
            _isBusy = false;

            TitleEventViewModels = new ObservableCollection<ITitleEventViewModel>();
            WorksheetViewModels = new ObservableCollection<IWorksheetViewModel>();
            ChainOfTitleViewModels = new ObservableCollection<IChainOfTitleViewModel>();
        }

        public async Task ShowPropertySearchesView(IFileReference fileReference)
        {
            SelectedIdex = 0;
            IsBusy = true;
            await Task.Delay(5000);
            IsBusy = false;
        }

        public async Task ShowPropertySearchLegalView(IFileReference fileReference)
        {
            SelectedIdex = 0;
            IsBusy = true;
            await Task.Delay(5000);
            IsBusy = false;
        }

        public async Task ShowPropertySearchView((IFileReference fileReference, int searchId) args)
        {
            SelectedIdex = 0;
            IsBusy = true;
            await Task.Delay(5000);
            IsBusy = false;
        }

        public async Task ShowChainOfTitlesView(IFileReference fileReference)
        {
            SelectedIdex = 2;
            IsBusy = true;
            await Task.Delay(5000);
            IsBusy = false;
        }

        public async Task ShowChainOfTitleView((IFileReference fileReference, int chainOfTitleId, int searchId) args)
        {
            SelectedIdex = 2;
            IsBusy = true;
            await Task.Delay(5000);
            IsBusy = false;
        }

        public async Task ShowWorksheetView(IFileReference fileReference)
        {
            SelectedIdex = 1;
            IsBusy = true;
            await Task.Delay(5000);
            IsBusy = false;
        }

        #endregion
    }
}
