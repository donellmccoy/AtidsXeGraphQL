using Ensure;
using JetBrains.Annotations;
using MaterialDesignThemes.Wpf;
using Prism.Events;
using ReactiveUI;
using System;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Enumerations.Search;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.WorkSpace.Services;
using DelegateCommand = Prism.Commands.DelegateCommand;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.Properties
{
    [Export(typeof(IPropertySearchTreeViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class PropertySearchTreeViewModel : ViewModelBase, IPropertySearchTreeViewModel
    {
        #region Fields

        private bool _isBusy;
        private bool _isContentVisible;
        private readonly IWorkspaceService _workspaceService;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public PropertySearchTreeViewModel(IEventAggregator eventAggregator, IWorkspaceService workspaceService) : 
            base(eventAggregator)
        {
            _workspaceService = workspaceService;
            Initialize();
        }

        #endregion

        #region Properties

        public IFileReference FileReference { get; set; }

        public int FileReferenceId { get; set; }

        public int SearchId { get; set; }

        public SearchType SearchType { get; set; }

        public bool IsOnChainOfTitle { get; set; }

        public bool IsHidden { get; set; }

        public string DateRange => $"{SearchFromDate.ToShortDateString()} - {SearchThruDate.ToShortDateString()}";

        public DateTime SearchFromDate { get; set; }    

        public DateTime SearchThruDate { get; set; }    

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

        public string LegalName { get; }

        public string InfoIconToolTip => $"Legal: {LegalName}";

        public bool IsContentVisible
        {
            get => _isContentVisible;
            set
            {
                _isContentVisible = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsEnabled => !_isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                this.RaisePropertyChanged();
            }
        }

        public IWorkspaceService WorkspaceService { get; }

        #endregion

        #region Commands

        public DelegateCommand SelectPropertySearchCommand { get; set; }

        private async void OnSelectPropertySearch()
        {
            await _workspaceService.ShowPropertySearchView((FileReference, SearchId));
        }

        private bool CanSelectPropertySearch()
        {
            return true;
        }

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
            return !IsOnChainOfTitle;
        }

        public DelegateCommand UnhideSearchCommand { get; set; }

        private static void OnUnhideSearchExecute()
        {

        }

        private bool CanUnhideSearchExecute()
        {
            return IsHidden;
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
            return !IsOnChainOfTitle;
        }

        public DelegateCommand ReplaceChainOfTitleCommand { get; set; }

        private static void OnReplaceChainOfTitleExecute()
        {

        }

        private bool CanReplaceChainOfTitleExecute()
        {
            return IsOnChainOfTitle;
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
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            SelectPropertySearchCommand = new DelegateCommand(OnSelectPropertySearch, CanSelectPropertySearch);
            EditSearchCommand = new DelegateCommand(OnEditSearchExecute, CanEditSearchExecute);
            HideSearchCommand = new DelegateCommand(OnHideSearchExecute, CanHideSearchExecute);
            ViewSearchParametersCommand = new DelegateCommand(OnViewSearchParametersExecute, CanViewSearchParametersExecute);
            ViewSearchNotesCommand = new DelegateCommand(OnViewSearchNotesExecute, CanViewSearchNotesExecute);
            HideSearchCommand = new DelegateCommand(OnHideSearchExecute, CanHideSearchExecute);
            CreateChainOfTitleCommand = new DelegateCommand(OnCreateChainOfTitleExecute, CanCreateChainOfTitleExecute);
            ReplaceChainOfTitleCommand = new DelegateCommand(OnReplaceChainOfTitleExecute, CanReplaceChainOfTitleExecute);
            ShareWithUserCommand = new DelegateCommand(OnShareWithUserExecute, CanShareWithUserExecute);
            ShowPropertyOnMapCommand = new DelegateCommand(OnShowPropertyOnMapExecute, CanShowPropertyOnMapExecute);
            UnhideSearchCommand = new DelegateCommand(OnUnhideSearchExecute, CanUnhideSearchExecute);
        }

        public void Build([NotNull] IFileReference fileReference, [NotNull] ISearch search, [NotNull] IPropertySearchLegalTreeViewModel parent)
        {
            fileReference.EnsureNotNull();
            search.EnsureNotNull();
            parent.EnsureNotNull();

            FileReference = fileReference;
            FileReferenceId = search.FileReferenceId;
            SearchId = search.SearchId;
            SearchFromDate = search.SearchFromDate;
            SearchThruDate = search.SearchThruDate;
            SearchType = (SearchType)search.SearchTypeId;
            Icon = GetSearchStatusIcon(search.SearchStatusId.GetValueOrDefault());
            IsBusy = false;
            IsContentVisible = true;
            IsOnChainOfTitle = false;
            IsHidden = false;
        }

        private static PackIconKind GetSearchStatusIcon(int searchStatusId)
        {
            switch (searchStatusId)
            {
                case 0:
                    return PackIconKind.CheckCircle;
                case 1:
                    return PackIconKind.AccountPending;
                case 2:
                    return PackIconKind.Loading;
                case 3:
                    return PackIconKind.Error;
                default:
                    return PackIconKind.CheckCircle;
            }
        }

        #endregion
    }
}