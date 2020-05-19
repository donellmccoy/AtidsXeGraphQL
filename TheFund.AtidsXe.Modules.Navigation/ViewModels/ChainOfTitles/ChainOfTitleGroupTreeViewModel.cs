using JetBrains.Annotations;
using Prism.Events;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Microsoft.Practices.ServiceLocation;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;
using TheFund.AtidsXe.Modules.WorkSpace.Services;
using DelegateCommand = Prism.Commands.DelegateCommand;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.ChainOfTitles
{
    [Export(typeof(IChainOfTitleGroupTreeViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class ChainOfTitleGroupTreeViewModel : ViewModelBase, IChainOfTitleGroupTreeViewModel
    {
        #region Fields

        private int _chainOfTitlesCount;
        private bool _isBusy;
        private readonly IWorkspaceService _workspaceService;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public ChainOfTitleGroupTreeViewModel(IEventAggregator eventAggregator, IWorkspaceService workspaceService) : base(eventAggregator)
        {
            _workspaceService = workspaceService;
            Initialize();
        }

        #endregion

        #region Properties

        public IOutlookBarItemViewModel Parent { get; set; }

        public ObservableCollection<IChainOfTitleTreeViewModel> ChainOfTitleViewModels { get; set; }

        public bool IsHidden { get; }

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

        public IFileReference FileReference { get; set; }

        public int ChainOfTitlesCount
        {
            get => _chainOfTitlesCount;
            set
            {
                _chainOfTitlesCount = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands

        public DelegateCommand SortByLotAscendingCommand { get; set; }

        private void OnSortByLotAscending()
        {
        }

        private bool CanSortByLotAscending()
        {
            return true;
        }

        public DelegateCommand SelectChainOfTitlesCommand { get; set; }

        private async void OnSelectChainOfTitles()
        {
            await _workspaceService.ShowChainOfTitlesView(FileReference);
        }

        private bool CanSelectChainOfTitles()
        {
            return !IsBusy;
        }

        public DelegateCommand ReplaceAllCommand { get; set; }

        private void OnReplaceAllChainOfTitles()
        {
            foreach (var chainOfTitleViewModel in ChainOfTitleViewModels)
            {
                if (chainOfTitleViewModel.RegenerateCommand.CanExecute())
                {
                    chainOfTitleViewModel.RegenerateCommand.Execute();
                }
            }
        }

        private static bool CanReplaceAllChainOfTitles()
        {
            return true;
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            ChainOfTitleViewModels = new ObservableCollection<IChainOfTitleTreeViewModel>();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            ReplaceAllCommand = new DelegateCommand(OnReplaceAllChainOfTitles, CanReplaceAllChainOfTitles);
            SelectChainOfTitlesCommand = new DelegateCommand(OnSelectChainOfTitles, CanSelectChainOfTitles);
        }

        public void SetProgressIndicatorOn()
        {
            IsBusy = true;
        }

        public void SetProgressIndicatorOff()
        {
            IsBusy = false;
        }

        public void Build([NotNull] IFileReference fileReference, [NotNull] IOutlookBarItemViewModel parent)
        {
            FileReference = fileReference;
            Parent = parent;

            foreach (var chainOfTitle in fileReference.ChainOfTitles)
            {
                var model = ServiceLocator.Current.GetInstance<IChainOfTitleTreeViewModel>();
                model.Build(chainOfTitle, fileReference, this);
                ChainOfTitleViewModels.Add(model);
            }

            ChainOfTitlesCount = ChainOfTitleViewModels.Count;
        }

        #endregion
    }
}