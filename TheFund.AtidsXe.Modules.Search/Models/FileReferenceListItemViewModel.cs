// ***********************************************************************
// Assembly         : TheFund.AtidsXe.Modules.Search
// Author           : Donell McCoy
// Created          : 02-18-2020
//
// Last Modified By : Donell McCoy
// Last Modified On : 03-19-2020
// ***********************************************************************
// <copyright file="SearchListItemViewModel.cs" company="Attorneys' Title Fund Services, LLC">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;
using Nito.Comparers;
using Nito.Comparers.Util;
using Nito.Mvvm;
using Prism.Commands;
using Prism.Events;
using ReactiveUI;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.ApplicationStatus.ViewModels;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Factories;
using TheFund.AtidsXe.Modules.Common.Models;
using TheFund.AtidsXe.Modules.Common.ViewModels;
using TheFund.AtidsXe.Modules.Search.ViewModels;
using TheFund.AtidsXe.Modules.Services.Logging;
using TheFund.AtidsXe.Modules.Services.User;

namespace TheFund.AtidsXe.Modules.Search.Models
{
    /// <summary>
    /// Class SearchListItemViewModel. This class cannot be inherited.
    /// Implements the <see cref="TheFund.AtidsXe.Modules.Common.ViewModels.ViewModelBase" />
    /// Implements the <see cref="System.IComparable{TheFund.AtidsXe.Modules.Search.Models.SearchListItemViewModel}" />
    /// Implements the <see cref="System.IComparable" />
    /// Implements the <see cref="System.IEquatable{TheFund.AtidsXe.Modules.Search.Models.SearchListItemViewModel}" />
    /// Implements the <see cref="IFileReferenceListItemViewModel" />
    /// </summary>
    /// <seealso cref="TheFund.AtidsXe.Modules.Common.ViewModels.ViewModelBase" />
    /// <seealso cref="System.IComparable{TheFund.AtidsXe.Modules.Search.Models.SearchListItemViewModel}" />
    /// <seealso cref="System.IComparable" />
    /// <seealso cref="System.IEquatable{TheFund.AtidsXe.Modules.Search.Models.SearchListItemViewModel}" />
    /// <seealso cref="IFileReferenceListItemViewModel" />
    [DebuggerDisplay("FileReferenceName: {FileReferenceName}, FileReferenceId: {FileReferenceId}")]
    [Export(typeof(IFileReferenceListItemViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class FileReferenceListItemViewModel : 
        ViewModelBase,
        IComparable<FileReferenceListItemViewModel>,
        IComparable,
        IEquatable<FileReferenceListItemViewModel>,
        IFileReferenceListItemViewModel
    {
        #region Fields

        private ObservableAsPropertyHelper<bool> _isFavorite;
        private ObservableAsPropertyHelper<bool> _isOpened;
        /// <summary>
        /// The image URL
        /// </summary>
        private string _imageUrl;
        /// <summary>
        /// The created date formatted
        /// </summary>
        private string _createdDateFormatted;
        /// <summary>
        /// The is busy
        /// </summary>
        private bool _isBusy;
        /// <summary>
        /// The is in use
        /// </summary>
        private bool _isInUse;
        private bool _isInWorkspace;
        private bool _allowFileHistory;
        private bool _isDirty;
        /// <summary>
        /// The logging service
        /// </summary>
        private readonly ILoggingService _loggingService;
        /// <summary>
        /// The user service
        /// </summary>
        private readonly IUserService _userService;
        /// <summary>
        /// The status bar message queue
        /// </summary>
        private readonly IStatusBarMessageQueue _statusBarMessageQueue;
        /// <summary>
        /// The default comparer
        /// </summary>
        public static readonly IFullComparer<FileReferenceListItemViewModel> DefaultComparer;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReferenceListItemViewModel"/> class.
        /// </summary>
        public FileReferenceListItemViewModel()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileReferenceListItemViewModel"/> class.
        /// </summary>
        /// <param name="loggingService">The logging service.</param>
        /// <param name="userService">The user service.</param>
        /// <param name="statusBarViewModel">The status bar view model.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="statusBarMessageQueue">The status bar message queue.</param>
        [ImportingConstructor]
        public FileReferenceListItemViewModel(ILoggingService loggingService, 
									   IUserService userService,
									   IStatusBarViewModel statusBarViewModel,
                                       IEventAggregator eventAggregator, 
									   IStatusBarMessageQueue statusBarMessageQueue) : 
            base(eventAggregator)
        {
            _loggingService = loggingService;
            _userService = userService;
			_statusBarMessageQueue = statusBarMessageQueue;

			_isBusy = false;
            _isDirty = false;
            _allowFileHistory = true;

            InitializeCommands();
        }

        //A static constructor is used to initialize any static data,
        //or to perform a particular action that needs to be performed once only
        /// <summary>
        /// Initializes static members of the <see cref="FileReferenceListItemViewModel"/> class.
        /// </summary>
        static FileReferenceListItemViewModel()
        {
            DefaultComparer = ComparerBuilder.For<FileReferenceListItemViewModel>().OrderBy(p => p.FileReferenceId);
        }

        #endregion
        
        #region Add Remove Favorites Command

        public ReactiveCommand<Unit, bool> AddRemoveFavoritesCommand { get; set; }

        #endregion

        #region Open Close File Command

        public ReactiveCommand<Unit, bool> OpenCloseFileCommand { get; set; }

        #endregion

        #region Add Remove From Workspace Command

        public DelegateCommand<bool?> AddRemoveFromWorkspaceCommand { get; set; }

        private async Task OnAddRemoveFromWorkspace(bool? isInWorkspace)
        {
            try
            {
                ShowBusyIndicator();

                if (isInWorkspace == false)
                {
                    ShowStatusBarMessage($"");
                    MarkInWorkspaceAs(true);
                }
                else
                {
                    ShowStatusBarMessage($"");
                    MarkInWorkspaceAs(false);
                }

                ClearStatusBarMessage();
                HideBusyIndicator();
                AddRemoveFromWorkspaceCommand.RaiseCanExecuteChanged();
            }
            catch (Exception e)
            {
                HideBusyIndicator();
                ShowStatusBarMessage();
                MarkInWorkspaceAs(isInWorkspace == false);
                AddRemoveFromWorkspaceCommand.RaiseCanExecuteChanged();
                await HandleException(e);
                ShowErrorMessage("Add/Remove from Workspace Error", $"Failed to add or remove file: {FileReferenceName} from workspace.");
            }
        }

        private bool CanAddRemoveFromWorkspace(bool? isInWorkspace)
        {
            return !_isBusy;
        }

        #endregion

        #region Show File History Command

        public DelegateCommand ShowFileHistoryCommand { get; set; }

        private async Task OnShowFileHistory()
        {
            try
            {
                ShowBusyIndicator();
                ClearStatusBarMessage();
                HideBusyIndicator();
                ShowFileHistoryCommand.RaiseCanExecuteChanged();
            }
            catch (Exception e)
            {
                HideBusyIndicator();
                ShowStatusBarMessage();
                ShowFileHistoryCommand.RaiseCanExecuteChanged();
                await HandleException(e);
                ShowErrorMessage("Add/Remove from Workspace Error", $"Failed to add or remove file: {FileReferenceName} from workspace.");
            }
        }

        private bool CanShowFileHistory()
        {
            return !_isBusy;
        }

        #endregion

        #region Find Related Files Command

        public DelegateCommand FindRelatedFilesCommand { get; set; }

        private async Task OnFindRelatedFiles()
        {
            try
            {
                ShowBusyIndicator();
                ClearStatusBarMessage();
                HideBusyIndicator();
                FindRelatedFilesCommand.RaiseCanExecuteChanged();
            }
            catch (Exception e)
            {
                HideBusyIndicator();
                ShowStatusBarMessage();
                FindRelatedFilesCommand.RaiseCanExecuteChanged();
                await HandleException(e);
                ShowErrorMessage("Add/Remove from Workspace Error", $"Failed to add or remove file: {FileReferenceName} from workspace.");
            }
        }

        private bool CanFindRelatedFiles()
        {
            return !_isBusy;
        }

        #endregion

        #region Save All Changes Command

        public DelegateCommand SaveAllChangesCommand { get; set; }

        private async Task OnSaveAllChanges()
        {
            try
            {
                ShowBusyIndicator();
                ClearStatusBarMessage();
                HideBusyIndicator();
                SaveAllChangesCommand.RaiseCanExecuteChanged();
            }
            catch (Exception e)
            {
                HideBusyIndicator();
                ShowStatusBarMessage();
                SaveAllChangesCommand.RaiseCanExecuteChanged();
                await HandleException(e);
                ShowErrorMessage("Add/Remove from Workspace Error", $"Failed to add or remove file: {FileReferenceName} from workspace.");
            }
        }

        private bool CanSaveAllChanges()
        {
            return !_isBusy && _isDirty;
        }

        #endregion

        #region Undo All Changes Command

        public DelegateCommand UndoAllChangesCommand { get; set; }

        private async Task OnUndoAllChanges()
        {
            try
            {
                ShowBusyIndicator();
                ClearStatusBarMessage();
                HideBusyIndicator();
                UndoAllChangesCommand.RaiseCanExecuteChanged();
            }
            catch (Exception e)
            {
                HideBusyIndicator();
                ShowStatusBarMessage();
                UndoAllChangesCommand.RaiseCanExecuteChanged();
                await HandleException(e);
                ShowErrorMessage("Add/Remove from Workspace Error", $"Failed to add or remove file: {FileReferenceName} from workspace.");
            }
        }

        private bool CanUndoAllChanges()
        {
            return !_isBusy && _isDirty;
        }

        #endregion

        #region Refresh File Command

        public DelegateCommand RefreshFileCommand { get; set; }

        private async Task OnRefreshFile()
        {
            try
            {
                ShowBusyIndicator();
                ClearStatusBarMessage();
                HideBusyIndicator();
                RefreshFileCommand.RaiseCanExecuteChanged();
            }
            catch (Exception e)
            {
                HideBusyIndicator();
                ShowStatusBarMessage();
                RefreshFileCommand.RaiseCanExecuteChanged();
                await HandleException(e);
                ShowErrorMessage("Add/Remove from Workspace Error", $"Failed to add or remove file: {FileReferenceName} from workspace.");
            }
        }

        private bool CanRefreshFile()
        {
            return !_isBusy;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance is busy.
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
			get => _isBusy;
			set
			{
				_isBusy = value;
				this.RaisePropertyChanged();
			}
		}

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>The parent.</value>
        public ISearchViewModel Parent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is favorite.
        /// </summary>
        /// <value><c>true</c> if this instance is favorite; otherwise, <c>false</c>.</value>
        public bool IsFavorite => _isFavorite?.Value ?? false;

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>The image URL.</value>
        public string ImageUrl
        {
            get => _imageUrl;
            set => this.RaiseAndSetIfChanged(ref _imageUrl, value);
        }

        /// <summary>
        /// Gets or sets the file reference identifier.
        /// </summary>
        /// <value>The file reference identifier.</value>
        public int FileReferenceId { get; set; }

        /// <summary>
        /// Gets or sets the name of the file reference.
        /// </summary>
        /// <value>The name of the file reference.</value>
        public string FileReferenceName { get; set; }

        /// <summary>
        /// Gets or sets the worker identifier.
        /// </summary>
        /// <value>The worker identifier.</value>
        public string WorkerId { get; set; }

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>The created date.</value>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the created date formatted.
        /// </summary>
        /// <value>The created date formatted.</value>
        public string CreatedDateFormatted
        {
            get => _createdDateFormatted;
            set
            {
                _createdDateFormatted = value;
                this.RaisePropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        /// <value>The update date.</value>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is temporary file.
        /// </summary>
        /// <value><c>true</c> if this instance is temporary file; otherwise, <c>false</c>.</value>
        public bool IsTemporaryFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has loaded.
        /// </summary>
        /// <value><c>true</c> if this instance has loaded; otherwise, <c>false</c>.</value>
        public bool HasLoaded { get; set; }

        /// <summary>
        /// Gets the has chain of titles text.
        /// </summary>
        /// <value>The has chain of titles text.</value>
        public string HasChainOfTitlesText => HasChainOfTitles ? "Yes" : "No";

        /// <summary>
        /// Gets or sets a value indicating whether this instance has chain of titles.
        /// </summary>
        /// <value><c>true</c> if this instance has chain of titles; otherwise, <c>false</c>.</value>
        public bool HasChainOfTitles { get; set; }

        /// <summary>
        /// Gets or sets the chain of titles count.
        /// </summary>
        /// <value>The chain of titles count.</value>
        public int ChainOfTitlesCount { get; set; }

        /// <summary>
        /// Gets or sets the policy searches count.
        /// </summary>
        /// <value>The policy searches count.</value>
        public int PolicySearchesCount { get; set; }

        /// <summary>
        /// Gets or sets the property searches count.
        /// </summary>
        /// <value>The property searches count.</value>
        public int PropertySearchesCount { get; set; }

        /// <summary>
        /// Gets or sets the name searches count.
        /// </summary>
        /// <value>The name searches count.</value>
        public int NameSearchesCount { get; set; }

        /// <summary>
        /// Gets or sets the file status.
        /// </summary>
        /// <value>The file status.</value>
        public FileStatus FileStatus { get; set; }

        /// <summary>
        /// Gets or sets the branch location.
        /// </summary>
        /// <value>The branch location.</value>
        public BranchLocation BranchLocation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value><c>true</c> if this instance is selected; otherwise, <c>false</c>.</value>
        public bool IsOpened => _isOpened?.Value ?? false;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is in use.
        /// </summary>
        /// <value><c>true</c> if this instance is in use; otherwise, <c>false</c>.</value>
        public bool IsInUse
        {
            get => _isInUse;
            set
            {
                _isInUse = value;
                this.RaisePropertyChanged();
            }
        }

        public bool IsInWorkspace
        {
            get => _isInWorkspace;
            set
            {
                _isInWorkspace = value;
                this.RaisePropertyChanged();
            }
        }

        public bool AllowFileHistory
        {
            get => _allowFileHistory;
            set
            {
                _allowFileHistory = value;
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

        public IFileReference FileReference { get; set; }

        #endregion

        #region Methods

        private void InitializeCommands()
        {
            var canExecute = this.WhenAnyValue(model => model.IsBusy, isBusy => !isBusy)
                                 .ObserveOn(RxApp.MainThreadScheduler);

            AddRemoveFavoritesCommand = ReactiveCommand.Create<Unit, bool>(_ => !_isFavorite.Value, canExecute, RxApp.TaskpoolScheduler);
            AddRemoveFavoritesCommand.ToProperty(this, model => model.IsFavorite, out _isFavorite, false, true, RxApp.MainThreadScheduler);

            OpenCloseFileCommand = ReactiveCommand.Create<Unit, bool>(_ => !_isOpened.Value, canExecute, RxApp.TaskpoolScheduler);
            OpenCloseFileCommand.ToProperty(this, model => model.IsOpened, out _isOpened, false, true, RxApp.MainThreadScheduler);

            AddRemoveFromWorkspaceCommand = new DelegateCommand<bool?>(async arg => await OnAddRemoveFromWorkspace(arg), CanAddRemoveFromWorkspace);
            ShowFileHistoryCommand = new DelegateCommand(async () => await OnShowFileHistory(), CanShowFileHistory);
            FindRelatedFilesCommand = new DelegateCommand(async () => await OnFindRelatedFiles(), CanFindRelatedFiles);
            SaveAllChangesCommand = new DelegateCommand(async () => await OnSaveAllChanges(), CanSaveAllChanges);
            UndoAllChangesCommand = new DelegateCommand(async () => await OnUndoAllChanges(), CanUndoAllChanges);
            RefreshFileCommand = new DelegateCommand(async () => await OnRefreshFile(), CanRefreshFile);
        }

        /// <summary>
        /// Queues the status bar message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void ShowStatusBarMessage(string message = null)
		{
			_statusBarMessageQueue.QueueMessage(message);
		}

        private void ClearStatusBarMessage()
        {
            ShowStatusBarMessage(null);
        }

        /// <summary>
        /// Shows the busy indicator.
        /// </summary>
        private void ShowBusyIndicator()
		{
			IsBusy = true;
		}

        /// <summary>
        /// Hides the busy indicator.
        /// </summary>
        private void HideBusyIndicator()
		{
			IsBusy = false;
		}

        /// <summary>
        /// Shows the error message.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="description">The description.</param>
        private static void ShowErrorMessage(string title, string description)
        {

        }

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        private async Task HandleException([NotNull] Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            await _loggingService.LogEntryAsync(exception.GetBaseException().Message).ConfigureAwait(false);
        }

        public void MarkInWorkspaceAs(bool isInWorkspace)
        {
            IsInWorkspace = isInWorkspace;
        }

        #endregion

        #region IEquatable<T>

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns><see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(FileReferenceListItemViewModel other)
        {
            return ComparableImplementations.ImplementEquals(DefaultComparer, this, other);
        }

        #endregion

        #region IComparable

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.</returns>
        int IComparable.CompareTo(object obj)
        {
            return ComparableImplementations.ImplementCompareTo(DefaultComparer, this, obj);
        }

        #endregion

        #region IComparable<T>

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order.</returns>
        public int CompareTo(FileReferenceListItemViewModel other)
        {
            return ComparableImplementations.ImplementCompareTo(DefaultComparer, this, other);
        }

        #endregion

        #region System.Object Overrides

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return ComparableImplementations.ImplementGetHashCode(DefaultComparer, this);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return ComparableImplementations.ImplementEquals(DefaultComparer, this, obj);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return FileReferenceName;
        }

        #endregion
    }
}