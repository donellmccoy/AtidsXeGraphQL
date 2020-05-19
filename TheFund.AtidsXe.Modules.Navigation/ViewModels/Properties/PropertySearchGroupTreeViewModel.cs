using Ensure;
using JetBrains.Annotations;
using Microsoft.Practices.ServiceLocation;
using Prism.Events;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;
using TheFund.AtidsXe.Modules.WorkSpace.Services;
using DelegateCommand = Prism.Commands.DelegateCommand;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.Properties
{
    [Export(typeof(IPropertySearchGroupTreeViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class PropertySearchGroupTreeViewModel : ViewModelBase, IPropertySearchGroupTreeViewModel
    {
        #region Fields

        private bool _isBusy;
        private readonly IWorkspaceService _workspaceService;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public PropertySearchGroupTreeViewModel(IEventAggregator eventAggregator, IWorkspaceService workspaceService) :
            base(eventAggregator)
        {
            _workspaceService = workspaceService;
            Initialize();
        }

        #endregion

        #region Properties

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

        public ObservableCollection<IPropertySearchLegalTreeViewModel> PropertySearchLegalViewModels { get; set; }

        public IOutlookBarItemViewModel Parent { get; set; }

        public IFileReference FileReference { get; set; }

        #endregion

        #region Commands

        public DelegateCommand SelectPropertySearchGroupCommand { get; set; }

        private async void OnSelectPropertySearchGroup()
        {
            await _workspaceService.ShowPropertySearchesView(FileReference);
        }

        private static bool CanSelectPropertySearchGroup()
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

        public DelegateCommand ViewSearchParametersCommand { get; set; }

        private static void OnViewSearchParameters()
        {

        }

        private static bool CanViewSearchParameters()
        {
            return true;
        }

        public DelegateCommand ViewSearchNotesCommand { get; set; }

        private static void OnViewSearchNotes()
        {

        }

        private static bool CanViewSearchNotes()
        {
            return true;
        }

        public DelegateCommand ShareWithUserCommand { get; set; }

        private static void OnShareWithUser()
        {

        }

        private bool CanShareWithUser()
        {
            return true;
        }

        public DelegateCommand ShowPropertyOnMapCommand { get; set; }

        private static void OnShowPropertyOnMap()
        {

        }

        private bool CanShowPropertyOnMap()
        {
            return true;
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            _isBusy = false;
            PropertySearchLegalViewModels = new ObservableCollection<IPropertySearchLegalTreeViewModel>();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            SelectPropertySearchGroupCommand = new DelegateCommand(OnSelectPropertySearchGroup, CanSelectPropertySearchGroup);
            EditSearchCommand = new DelegateCommand(OnEditSearch, CanEditSearch);
            ViewSearchParametersCommand = new DelegateCommand(OnViewSearchParameters, CanViewSearchParameters);
            ViewSearchNotesCommand = new DelegateCommand(OnViewSearchNotes, CanViewSearchNotes);
            ShareWithUserCommand = new DelegateCommand(OnShareWithUser, CanShareWithUser);
            ShowPropertyOnMapCommand = new DelegateCommand(OnShowPropertyOnMap, CanShowPropertyOnMap);
        }

        public void Build([NotNull] IFileReference fileReference, [NotNull] IOutlookBarItemViewModel parent)
        {
            fileReference.EnsureNotNull();
            parent.EnsureNotNull();

            FileReference = fileReference;
            Parent = parent;

            foreach (var propertySearch in fileReference.PropertySearches)
            {
                var model = ServiceLocator.Current.GetInstance<IPropertySearchLegalTreeViewModel>();
                model.Build(fileReference, propertySearch, this);
                PropertySearchLegalViewModels.Add(model);
            }
        }

        #endregion
    }
}