using Prism.Commands;
using Prism.Events;
using ReactiveUI;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Telerik.Windows.Data;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Constants;
using TheFund.AtidsXe.Modules.Common.Extensions;
using TheFund.AtidsXe.Modules.Common.Factories;
using TheFund.AtidsXe.Modules.Common.Models;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.Navigation.Services;
using TheFund.AtidsXe.Modules.Services.Caching;
using TheFund.AtidsXe.Modules.Services.Configuration;
using TheFund.AtidsXe.Modules.Services.Logging;
using TheFund.AtidsXe.Modules.Services.RecentItems;
using TheFund.AtidsXe.Modules.Services.Search;
using TheFund.AtidsXe.Modules.Services.User;
using TheFund.AtidsXe.Modules.Services.UserProfile;
using TheFund.AtidsXe.Modules.UserProjects.Collections;
using TheFund.AtidsXe.Modules.UserProjects.Enumerations;
using TheFund.AtidsXe.Modules.UserProjects.Factories;
using State = TheFund.AtidsXe.Modules.UserProjects.Enumerations.State;

namespace TheFund.AtidsXe.Modules.UserProjects.ViewModels
{
    [Export(typeof(IUserProjectsViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class UserProjectsViewModel : ViewModelBase, IUserProjectsViewModel
    {
        #region Fields

        private readonly IDisposable _cleanup = new CompositeDisposable();
        private readonly INavigationService _navigationService;
        private readonly ICachingServiceV3 _cachingService;
        private readonly ISearchService _searchService;
        private readonly ILoggingService _loggingService;
        private readonly IUserService _userService;
        private readonly IUserProfileService _userProfileService;
        private readonly IConfigurationService _configurationService;
        private int _profileCount;
        private string _profileName;
        private string _profileDescription;
        private IProfileListItem _selectedProfileListItem;
        private IProfileListItemCollection _profileListItems;
        private IFileReference _selectedFileReference;
        private RadObservableCollection<IFileReference> _profileFileReferences;
        private bool _isBusy;

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


        public bool IsEditingEnabled => _stateMachine.IsInState(State.Editing);

        public bool IsSelectionEnabled => !_stateMachine.IsInState(State.Editing) && HasProfiles;

        public int ProfileCount
        {
            get => _profileCount;
            set
            {
                _profileCount = value;
                this.RaisePropertyChanged();
            }
        }

        public string ProfileName
        {
            get => _profileName;
            set
            {
                _profileName = value;
                this.RaisePropertyChanged();
            }
        }

        public string ProfileDescription
        {
            get => _profileDescription;
            set
            {
                _profileDescription = value;
                this.RaisePropertyChanged();
            }
        }

        public RadObservableCollection<IFileReference> ProfileFileReferences
        {
            get => _profileFileReferences;
            set
            {
                _profileFileReferences = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsProfileLoaded => HasSelectedProfile && _selectedProfileListItem.IsLoaded;

        public bool HasSelectedProfile => _selectedProfileListItem.IsNotNull();

        public bool HasProfiles => ProfileListItems.HasItems;

        public IProfileListItem SelectedProfileListItem
        {
            get => _selectedProfileListItem;
            set
            {
                _selectedProfileListItem = value;
                this.RaisePropertyChanged();

                ProfileFileReferences.Clear();

                if (_selectedProfileListItem.IsNotNull())
                {
                    ProfileName = _selectedProfileListItem.ProfileName;
                    ProfileDescription = _selectedProfileListItem.Description;
                    ProfileFileReferences.AddRange(_selectedProfileListItem.FileReferences);
                }
                else
                {
                    ProfileName = null;
                    ProfileDescription = null;
                }
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

        public IProfileListItemCollection ProfileListItems
        {
            get => _profileListItems;
            set
            {
                _profileListItems = value;
                this.RaisePropertyChanged();
            }
        }

        #endregion

        #region Commands

        #region CloseProfileCommand

        public DelegateCommand CloseProfileCommand { get; set; }

        private static void ExecuteCloseProfile()
        {

        }

        private static bool CanExecuteCloseProfile()
        {
            return true;
        }

        #endregion

        public DelegateCommand SelectedProfileCommand { get; set; }

        public DelegateCommand LoadProfileCommand { get; set; }

        public DelegateCommand EditProfileCommand { get; set; }

        public DelegateCommand SaveEditProfileCommand { get; set; }

        public DelegateCommand CancelEditProfileCommand { get; set; }

        public DelegateCommand AddProfileCommand { get; set; }

        public DelegateCommand DeleteProfileCommand { get; set; }

        #endregion

        #region Constructors

        public UserProjectsViewModel(
                INavigationService navigationService,
                IEventAggregator eventAggregator,
                ICachingServiceV3 cachingService,
                ISearchService searchService,
                ILoggingService loggingService,
                IUserService userService,
                IRecentSearchesService recentSearchesService,
                IUserProfileService userProfileService,
                IConfigurationService configurationService) : base(eventAggregator)
        {
            _navigationService = navigationService;
            _cachingService = cachingService;
            _searchService = searchService;
            _loggingService = loggingService;
            _userService = userService;
            _userProfileService = userProfileService;
            _configurationService = configurationService;

            Initialize();
        }

        #endregion

        #region Methods

        private void Initialize()
        {
            _profileCount = 0;
            _profileName = null;
            _profileDescription = null;
            _selectedProfileListItem = null;
            _selectedFileReference = null;

            ProfileListItems = new ProfileListItemCollection();
            ProfileFileReferences = new RadObservableCollection<IFileReference>();

            RegisterCacheRegions();
            ConfigureStateMachine();
            InitializeCommands();
        }

        private void RegisterCacheRegions()
        {
            _cachingService.RegisterCacheRegions
            (
                CacheRegions.UserProfiles,
                CacheRegions.UserProfile,
                CacheRegions.LoadedProfiles,
                CacheRegions.ProfileEdit
            );
        }

        private void InitializeCommands()
        {
            SelectedProfileCommand = _stateMachine.CreateCommand(Trigger.Select);
            LoadProfileCommand = _stateMachine.CreateCommand(Trigger.Load);
            EditProfileCommand = _stateMachine.CreateCommand(Trigger.Edit);
            SaveEditProfileCommand = _stateMachine.CreateCommand(Trigger.SaveEdit);
            CancelEditProfileCommand = _stateMachine.CreateCommand(Trigger.CancelEdit);
            AddProfileCommand = _stateMachine.CreateCommand(Trigger.Add);
            DeleteProfileCommand = _stateMachine.CreateCommand(Trigger.Delete);
            CloseProfileCommand = DelegateCommandFactory.Create(ExecuteCloseProfile, CanExecuteCloseProfile);
        }

        private void ConfigureStateMachine()
        {
            _stateMachine = new StateMachine<State, Trigger>(State.UnSelected);
            _stateMachine.OnUnhandledTrigger(OnUnhandledTrigger);
            _stateMachine.OnTransitioned(transition =>
            {
                RefreshCommands();
#if DEBUG
                LogTransition(transition);
#endif
            });

            Func<bool> guard = () => HasSelectedProfile && !IsProfileLoaded && HasProfiles;

            _stateMachine.Configure(State.UnSelected)
                .OnEntryFromAsync(Trigger.Delete, OnDeleteProfileAsync)
                .Permit(Trigger.Select, State.Selected);

            _stateMachine.Configure(Enumerations.State.Selected)
                .OnEntryFromAsync(Trigger.SaveEdit, OnSaveProfileEditAsync)
                .OnEntryFrom(Trigger.CancelEdit, OnCancelProfileEdit)
                .PermitReentry(Trigger.Select)
                .PermitIf(Trigger.Edit, State.Editing, guard)
                .PermitIf(Trigger.Delete, State.UnSelected, guard)
                .PermitIf(Trigger.Load, State.Loaded, guard);

            _stateMachine.Configure(State.Editing)
                .OnEntryFrom(Trigger.Edit, OnEditProfile)
                .Permit(Trigger.CancelEdit, State.Selected)
                .Permit(Trigger.SaveEdit, State.Selected);

            _stateMachine.Configure(State.Loaded)
                .OnEntryFromAsync(Trigger.Load, OnLoadProfileAsync)
                .Permit(Trigger.Select, State.Selected)
                .Permit(Trigger.Unload, State.Selected);

            var graph = UmlDotGraph.Format(_stateMachine.GetInfo());
        }

        private async Task OnDeleteProfileAsync()
        {
            try
            {
                _userProfileService
                    .DeleteProfile(_selectedProfileListItem.UserId, _selectedProfileListItem.ProfileId)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Finally(async () =>
                    {
                        ProfileListItems.RemoveItem(_selectedProfileListItem);
                        //make observable
                        ProfileCount = ProfileListItems.ItemCount;
                    })
                    .Subscribe()
                    .DisposeWith(_cleanup as CompositeDisposable);

            }
            catch (AggregateException e)
            {
                await _loggingService.LogEntryAsync(e.GetBaseException().Message).ConfigureAwait(false);
            }
        }

        private async Task OnLoadProfileAsync()
        {
            try
            {
                await ProfileListItems.SetAllNotLoaded().AsCompletion();
                SelectedProfileListItem.IsLoaded = true;
            }
            catch (AggregateException e)
            {
                await _loggingService.LogEntryAsync(e.GetBaseException().Message).ConfigureAwait(false);
            }
        }

        private void OnEditProfile()
        {
            Backup();
        }

        private async Task LoadUserProfilesAsync()
        {
            try
            {
                SetBusyIndicatorOnObservable(o =>
                {
                    _userService.GetUserObservable(1)
                        .SubscribeOn(RxApp.TaskpoolScheduler)
                        .ObserveOn(RxApp.TaskpoolScheduler)
                        .SelectMany(userItem => _userProfileService.GetUserProfilesAsync(userItem.UserId))
                        .SubscribeOn(RxApp.TaskpoolScheduler)
                        .ObserveOn(RxApp.MainThreadScheduler)
                        .Subscribe(userProfileItems =>
                        {
                            SetBusyIndicatorOffObservable(_ =>
                            {
                                if (userProfileItems.Any())
                                {
                                    ProfileListItems.AddItems(userProfileItems.Select(p => ProfileListItemFactory.Create
                                        (
                                            p.UserProfile.UserId,
                                            p.UserProfile.ProfileId,
                                            p.UserProfile.Name,
                                            p.UserProfile.Description,
                                            p.UserProfile.CreatedBy,
                                            p.UserProfile.CreatedDate,
                                            p.UserProfile.ModifiedBy,
                                            p.UserProfile.ModifiedDate,
                                            p.UserProfile.UserProfileFileReferences.Select(t => t.FileReference))
                                    ));
                                }

                                ProfileCount = ProfileListItems.ItemCount;

                                RefreshCommands();
                            });
                        });
                }).DisposeWith(_cleanup as CompositeDisposable);
            }
            catch (AggregateException e)
            {
                await _loggingService.LogEntryAsync(e.GetBaseException().Message);
            }
        }

        public void SetProgressIndicatorOn()
        {
            IsBusy = true;
        }

        public IDisposable SetBusyIndicatorOnObservable(Action<Unit> action)
        {
            return Observable.Start(() => { IsBusy = true; })
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(action)
                .DisposeWith(_cleanup as CompositeDisposable);
        }

        public void SetProgressIndicatorOff()
        {
            IsBusy = false;
        }

        public IDisposable SetBusyIndicatorOffObservable(Action<Unit> action)
        {
            return Observable.Start(() => { IsBusy = false; })
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(action)
                .DisposeWith(_cleanup as CompositeDisposable);
        }

        public IObservable<Unit> SetBusyIndicatorOffObservable()
        {
            return Observable.Start(() => { IsBusy = false; })
                .ObserveOn(RxApp.MainThreadScheduler);
        }

        private void RefreshCommands()
        {
            LoadProfileCommand.RaiseCanExecuteChanged();
            EditProfileCommand.RaiseCanExecuteChanged();
            DeleteProfileCommand.RaiseCanExecuteChanged();
            SaveEditProfileCommand.RaiseCanExecuteChanged();
            CancelEditProfileCommand.RaiseCanExecuteChanged();
            AddProfileCommand.RaiseCanExecuteChanged();
            SelectedProfileCommand.RaiseCanExecuteChanged();

            this.RaisePropertyChanged(nameof(IsEditingEnabled));
            this.RaisePropertyChanged(nameof(IsSelectionEnabled));
        }

        private void Backup()
        {
            _cachingService.AddItem(nameof(ProfileName), _selectedProfileListItem.ProfileName, CacheRegions.ProfileEdit);
            _cachingService.AddItem(nameof(ProfileDescription), _selectedProfileListItem.Description, CacheRegions.ProfileEdit);
            _cachingService.AddItem(nameof(ProfileFileReferences), new RadObservableCollection<IFileReference>(_selectedProfileListItem.FileReferences), CacheRegions.ProfileEdit);
        }

        private void Restore()
        {
            ProfileName = _cachingService.GetItem<string>(nameof(ProfileName), CacheRegions.ProfileEdit);
            ProfileDescription = _cachingService.GetItem<string>(nameof(ProfileDescription), CacheRegions.ProfileEdit);
            ProfileFileReferences.Clear();
            ProfileFileReferences.AddRange(_cachingService.GetItem<RadObservableCollection<IFileReference>>(nameof(ProfileFileReferences), CacheRegions.ProfileEdit));

            DeleteBackup();
        }

        private void DeleteBackup()
        {
            _cachingService.ClearRegion(CacheRegions.ProfileEdit);
        }

        private void OnCancelProfileEdit()
        {
            Restore();
        }

        private async Task OnSaveProfileEditAsync()
        {
            try
            {
                var message = $"Updating profile: {SelectedProfileListItem.ProfileName}. Please wait...";

                var userProfile = new UserProfile
                {
                    UserId = SelectedProfileListItem.UserId,
                    ProfileId = SelectedProfileListItem.ProfileId,
                    Name = ProfileName,
                    Description = ProfileDescription,
                    CreatedBy = SelectedProfileListItem.CreatedBy,
                    CreatedDate = SelectedProfileListItem.CreatedDate,
                    ModifiedDate = DateTime.Now,
                    ModifiedBy = 1
                };

                await _userProfileService.UpdateUserProfileAsync(userProfile);

                SelectedProfileListItem.ProfileName = ProfileName;
                SelectedProfileListItem.Description = ProfileDescription;
                SelectedProfileListItem.FileReferences.Clear();
                SelectedProfileListItem.FileReferences.AddRange(ProfileFileReferences);
                SelectedProfileListItem.ModifiedDate = DateTime.Now;
                SelectedProfileListItem.ModifiedBy = 1;

                DeleteBackup();
            }
            catch (Exception e)
            {
                //show message that update failed, then restore
                Restore();
                await _loggingService.LogEntryAsync(e.GetBaseException().Message);
            }
            finally
            {
            }
        }

        private static void LogTransition(StateMachine<State, Trigger>.Transition transition)
        {
            Console.WriteLine($"[Trigger {transition.Trigger}] From state: {transition.Source} --> To state: {transition.Destination}");
        }

        private static void OnUnhandledTrigger(State state, Trigger trigger)
        {
            var message = $"State machine received an invalid trigger '{trigger}' in state '{state}'";
            Console.WriteLine(message);
        }

        #endregion
    }
}
