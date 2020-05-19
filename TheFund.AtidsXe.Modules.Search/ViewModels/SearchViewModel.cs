using DynamicData;
using JetBrains.Annotations;
using Prism.Events;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicData.Binding;
using TheFund.AtidsXe.Modules.ApplicationStatus.ViewModels;
using TheFund.AtidsXe.Modules.Common.Constants;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Events.EventArguments;
using TheFund.AtidsXe.Modules.Common.Events.Search;
using TheFund.AtidsXe.Modules.Common.Extensions;
using TheFund.AtidsXe.Modules.Common.Factories;
using TheFund.AtidsXe.Modules.Common.Models;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.Search.Extensions;
using TheFund.AtidsXe.Modules.Search.Factories;
using TheFund.AtidsXe.Modules.Search.Models;
using TheFund.AtidsXe.Modules.Search.StateMachines;
using TheFund.AtidsXe.Modules.Services.Caching;
using TheFund.AtidsXe.Modules.Services.Configuration;
using TheFund.AtidsXe.Modules.Services.Factories;
using TheFund.AtidsXe.Modules.Services.Logging;
using TheFund.AtidsXe.Modules.Services.RecentItems;
using TheFund.AtidsXe.Modules.Services.Search;
using TheFund.AtidsXe.Modules.Services.User;
using TheFund.AtidsXe.Modules.Services.UserProfile;
using System.Reactive.Subjects;
using System.Reactive.Concurrency;
using TheFund.AtidsXe.Modules.Services.GraphQL;

namespace TheFund.AtidsXe.Modules.Search.ViewModels
{
    [Export(typeof(ISearchViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class SearchViewModel : ViewModelBase, ISearchViewModel, IPartImportsSatisfiedNotification
    {
        #region Fields

        private CancellationTokenSource _cancellationTokenSource;
        private bool _isSearching;
        private string _busyMessage;
        private string _searchTerm;
        private string _favoritesHeader;
        private readonly ISearchService _searchService;
        private readonly ILoggingService _loggingService;
        private readonly IUserService _userService;
        private readonly IConfigurationService _configurationService;
        private readonly IStatusBarViewModel _statusBarViewModel;
        private readonly IStatusBarMessageQueue _statusBarMessageQueue;
        private readonly ISearchResultCollection _searchResultCollection;
        private readonly IGraphQLService _graphQLService;
        private readonly IRecentSearchesService _recentSearchesService;
        private readonly IEventAggregator _eventAggregator;
        private readonly ICachingService _cachingService;
        private CompositeDisposable _cleanup;
        private IFileReferenceListItemViewModel _selectedFileReferenceViewModelItem;
        private IRecentSearchTerm _selectedRecentSearchTerm;
        private IFileReference _selectedFileReference;
        private ObservableAsPropertyHelper<bool> _isBusy;
        private ObservableAsPropertyHelper<int> _searchResultsCount;
        private ObservableAsPropertyHelper<IEnumerable<IFileReferenceListItemViewModel>> _searchViewModelListItems;
        private ReadOnlyObservableCollection<IFileReferenceListItemViewModel> _favoriteViewModelListItems;
        private ReadOnlyObservableCollection<IRecentSearchTerm> _recentSearchTerms;

        #endregion

        #region Properties

        public bool IsBusy => _isBusy?.Value ?? false;

        public string BusyMessage
        {
            get => _busyMessage;
            set
            {
                _busyMessage = value;
                this.RaisePropertyChanged();
            }
        }


        public IFileReference SelectedFileReference
        {
            get => _selectedFileReference;
            set
            {
                _selectedFileReference = value;
                this.RaisePropertyChanged();
            }
        }

        public IRecentSearchTerm SelectedRecentSearchTerm
        {
            get => _selectedRecentSearchTerm;
            set
            {
                _selectedRecentSearchTerm = value;
                this.RaisePropertyChanged();
            }
        }

        public string SearchTerm
        {
            get => _searchTerm;
            set => this.RaiseAndSetIfChanged(ref _searchTerm, value);
        }

        public string FavoritesHeader
        {
            get => _favoritesHeader;
            set
            {
                _favoritesHeader = value;
                this.RaisePropertyChanged();
            }
        }

        public int SearchResultsCount => _searchResultsCount?.Value ?? 0;

        public IFileReferenceListItemViewModel SelectedFileReferenceListItemViewModel
        {
            get => _selectedFileReferenceViewModelItem;
            set => this.RaiseAndSetIfChanged(ref _selectedFileReferenceViewModelItem, value);
        }

        public bool IsSearching
        {
            get => _isSearching;
            set
            {
                _isSearching = value;
                this.RaisePropertyChanged();
            }
        }

        public IConnectableObservable<IEnumerable<FileReferenceListItemViewModel>> SearchTermConnectable { get; set; }

        public IEnumerable<IFileReferenceListItemViewModel> SearchListItemViewModels => _searchViewModelListItems.Value;

        public ReadOnlyObservableCollection<IFileReferenceListItemViewModel> FavoriteListItemViewModels => _favoriteViewModelListItems;

        public ReadOnlyObservableCollection<IRecentSearchTerm> RecentSearchTerms => _recentSearchTerms;

        public SourceList<IFileReferenceListItemViewModel> SearchListItems { get; set; }

        public bool HasSearchListItems => _searchViewModelListItems?.Value.Any() == true;

        public bool IsCompleted { get; set; }

        #endregion

        #region Commands

        #region LoadFileReferenceCommand

        public ReactiveCommand<IFileReferenceListItemViewModel, IFileReference> LoadFileReferenceCommand { get; set; }

        private async Task<IFileReference> OnLoadFileReferenceCommand([NotNull] IFileReferenceListItemViewModel model, CancellationToken token = default)
        {
            //model.MarkFileOpenedAs(true);

            ShowStatusMessage($"Loading file reference: {model.FileReferenceName}. Please wait...");
            ShowBusyIndicator();

            var response = await _searchService.GetFileReferenceAsync(FileReferenceRequestFactory.Create(model.FileReferenceId, token), token);

            ShowStatusMessage(null);
            HideBusyIndicator();

            return response.FileReference;
        }

        #endregion

        #endregion

        #region Constructors

        public SearchViewModel()
        {

        }

        [ImportingConstructor]
        public SearchViewModel(
            IEventAggregator eventAggregator,
            ISearchService searchService,
            ICachingService cachingService,
            ILoggingService loggingService,
            IUserService userService,
            IRecentSearchesService recentSearchesService,
            IUserProfileService userProfileService,
            IConfigurationService configurationService,
            IStatusBarViewModel statusBarViewModel,
            IGraphQLService graphQlService,
            IStatusBarMessageQueue statusBarMessageQueue,
            ISearchResultCollection searchResultCollection)
        {
            _eventAggregator = eventAggregator;
            _searchService = searchService;
            _loggingService = loggingService;
            _userService = userService;
            _cachingService = cachingService;
            _recentSearchesService = recentSearchesService;
            _configurationService = configurationService;
            _statusBarViewModel = statusBarViewModel;
            _statusBarMessageQueue = statusBarMessageQueue;
            _searchResultCollection = searchResultCollection;
            _graphQLService = graphQlService;

            Initialize();
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            _cleanup = new CompositeDisposable();
            _cancellationTokenSource = new CancellationTokenSource();
            _selectedFileReference = null;
            SearchListItems = new SourceList<IFileReferenceListItemViewModel>();
            IsSearching = false;

            InitializeReactives();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            var canExecute = this.WhenAnyValue
            (
                model => model.SelectedFileReferenceListItemViewModel,
                listItem => listItem != null && !listItem.IsOpened
            );

            LoadFileReferenceCommand = ReactiveCommand.CreateFromTask<IFileReferenceListItemViewModel, IFileReference>
            (
                OnLoadFileReferenceCommand,
                canExecute,
                RxApp.MainThreadScheduler
            );

            LoadFileReferenceCommand
                .ThrownExceptions
                .Subscribe(async ex => await _loggingService.LogEntryAsync(ex.GetBaseException().Message))
                .DisposeWith(_cleanup as CompositeDisposable);
        }

        private void InitializeReactives()
        {
            var shared = this.WhenValueChanged(model => model.SearchTerm, false)
                             .Throttle(_configurationService.SearchDueTime)
                             .Select(term => Observable.FromAsync(() => SearchFileReferencesAsync(term)))
                             .Switch()
                             .ToObservableChangeSet()
                             .Publish();

            shared.Transform(p => p)
                  .SubscribeOn(RxApp.TaskpoolScheduler)
                  .ObserveOnDispatcher()
                  .ToCollection()
                  .ToProperty(this, model => model.SearchListItemViewModels, out _searchViewModelListItems)
                  .DisposeWith(_cleanup);

            this.WhenValueChanged(model => model.IsSearching, false)
                .SubscribeOn(RxApp.TaskpoolScheduler)
                .ObserveOnDispatcher()
                .ToProperty(this, model => model.IsBusy, out _isBusy, false, true)
                .DisposeWith(_cleanup);

            _recentSearchesService.Connect()
                                  .Transform(RecentItemsFactory.Create)
                                  .SubscribeOn(RxApp.TaskpoolScheduler)
                                  .ObserveOnDispatcher()
                                  .Bind(out _recentSearchTerms, 6)
                                  .DisposeMany()
                                  .Subscribe()
                                  .DisposeWith(_cleanup);
            shared.Connect();
        }

        private async Task<IEnumerable<IFileReferenceListItemViewModel>> SearchFileReferencesAsync(string searchTerm, CancellationToken token = default)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Enumerable.Empty<FileReferenceListItemViewModel>();
            }

            ShowBusyIndicator();
            ShowStatusMessage($"Searching for file reference: '{searchTerm}'. Please wait...");

            var fileReferences = await _searchService.SearchFileReferencesAsync(searchTerm, token);
            var models = SearchViewModelListItemFactory.Create(fileReferences, this);

            await _recentSearchesService.AddSearchTermAsync(searchTerm, token);

            ShowStatusMessage();
            HideBusyIndicator();

            return models;
        }

        private void ShowStatusMessage(string message = null)
        {
            _statusBarMessageQueue.QueueMessage(new StatusBarMessage(message));
        }

        public void HideBusyIndicator()
        {
            IsSearching = false;
        }

        public void ShowBusyIndicator()
        {
            IsSearching = true;
        }

        public void OnImportsSatisfied()
        {
        }

        private async Task PopulateFavoritesAsync()
        {
            var response = await _userService.GetUserFavoritesAsync(1, 1, CancellationToken.None);

        }

        public void Dispose()
        {
            _cleanup?.Dispose();
        }

        #endregion
    }
}
