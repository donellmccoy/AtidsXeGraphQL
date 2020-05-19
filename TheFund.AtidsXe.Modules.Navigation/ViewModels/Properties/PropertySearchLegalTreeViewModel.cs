using Ensure;
using JetBrains.Annotations;
using MaterialDesignThemes.Wpf;
using Microsoft.Practices.ServiceLocation;
using Prism.Events;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Enumerations.Search;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.WorkSpace.Services;
using DelegateCommand = Prism.Commands.DelegateCommand;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.Properties
{
    [Export(typeof(IPropertySearchLegalTreeViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class PropertySearchLegalTreeViewModel : ViewModelBase, IPropertySearchLegalTreeViewModel
    {
        #region Fields

        private bool _isBusy;
        private readonly IWorkspaceService _workspaceService;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public PropertySearchLegalTreeViewModel(IEventAggregator eventAggregator, IWorkspaceService workspaceService) : 
            base(eventAggregator)
        {
            _workspaceService = workspaceService;
            Initialize();
        }

        #endregion

        #region Properties

        public int FileReferenceId { get; set; }

        public int SearchId { get; set; }

        public SearchType SearchType { get; set; }

        public string Color
        {
            get
            {
                switch (Icon)
                {
                    case PackIconKind.CheckCircle:
                        return "#FF008000";
                    case PackIconKind.AlertCircle:
                        return "Red";
                    case PackIconKind.Warning:
                        return "#FFFFCA00";
                    default:
                        return "#FF008000";
                }
            }
        }

        public PackIconKind Icon { get; set; }

        public string LegalName { get; set; }

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

        public IPropertySearchGroupTreeViewModel Parent { get; set; }

        public ObservableCollection<IPropertySearchTreeViewModel> PropertySearchViewModels { get; set; }

        public IWorkspaceService WorkspaceService { get; }

        #endregion

        #region Commands

        public DelegateCommand SelectPropertySearchLegalCommand { get; set; }

        private async void OnSelectPropertySearchLegal()
        {
            await _workspaceService.ShowPropertySearchLegalView(FileReference);
        }

        private bool CanSelectPropertySearchLegal()
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
            PropertySearchViewModels = new ObservableCollection<IPropertySearchTreeViewModel>();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            SelectPropertySearchLegalCommand = new DelegateCommand(OnSelectPropertySearchLegal, CanSelectPropertySearchLegal);
            EditSearchCommand = new DelegateCommand(OnEditSearch, CanEditSearch);
            ViewSearchParametersCommand = new DelegateCommand(OnViewSearchParameters, CanViewSearchParameters);
            ViewSearchNotesCommand = new DelegateCommand(OnViewSearchNotes, CanViewSearchNotes);
            ShareWithUserCommand = new DelegateCommand(OnShareWithUser, CanShareWithUser);
            ShowPropertyOnMapCommand = new DelegateCommand(OnShowPropertyOnMap, CanShowPropertyOnMap);
        }

        public void Build([NotNull] IFileReference fileReference, [NotNull] ISearch search, [NotNull] IPropertySearchGroupTreeViewModel parent)
        {
            search.EnsureNotNull();
            parent.EnsureNotNull();

            SearchId = search.SearchId;
            Parent = parent;
            FileReferenceId = search.FileReferenceId;
            LegalName = CreateLegalName(search);
            SearchType = (SearchType) search.SearchTypeId;

            var model = ServiceLocator.Current.GetInstance<IPropertySearchTreeViewModel>();
            model.Build(fileReference, search, this);

            PropertySearchViewModels.Add(model);
        }

        private static string CreateLegalName([NotNull] ISearch search)
        {
            return "13 PB (22/15)";
        }

        #endregion
    }
}