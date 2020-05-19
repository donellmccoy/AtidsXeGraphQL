using DynamicData;
using DynamicData.Binding;
using Ensure;
using JetBrains.Annotations;
using Prism.Commands;
using Prism.Events;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.ApplicationStatus.ViewModels;
using TheFund.AtidsXe.Modules.Common.Constants;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Extensions;
using TheFund.AtidsXe.Modules.Common.Models;
using TheFund.AtidsXe.Modules.Navigation.Factories;
using TheFund.AtidsXe.Modules.Search.Models;
using TheFund.AtidsXe.Modules.Search.ViewModels;
using TheFund.AtidsXe.Modules.Services.Caching;
using TheFund.AtidsXe.Modules.WorkSpace.Services;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar
{
    [Export(typeof(IOutlookBarViewModel))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class OutlookBarViewModel : ReactiveObject, IOutlookBarViewModel, IPartImportsSatisfiedNotification
    {
        #region Fields

        private int _filesOpenedCount;
        private IOutlookBarItemViewModel _selectedOutlookBarItemViewModel;
        private readonly IStatusBarMessageQueue _statusBarMessageQueue;
        private readonly IWorkspaceService _workspaceService;
        private static IEventAggregator _eventAggregator;
        private readonly ICachingService _cachingService;
        private readonly IOutlookBarItemViewModelFactory _modelFactory;
        private readonly ISearchViewModel _searchViewModel;
        private CompositeDisposable _cleanup;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public OutlookBarViewModel(
            IWorkspaceService workspaceService,
            IEventAggregator eventAggregator,
            ICachingService cachingService,
            IStatusBarMessageQueue statusBarMessageQueue,
            IOutlookBarItemViewModelFactory modelFactory,
            ISearchViewModel searchViewModel)
        {
            _workspaceService = workspaceService;
            _eventAggregator = eventAggregator;
            _cachingService = cachingService;
            _statusBarMessageQueue = statusBarMessageQueue;
            _modelFactory = modelFactory;
            _searchViewModel = searchViewModel;

            Initialize();
        }

        #endregion

        #region Properties

        public int FilesOpenedCount
        {
            get => _filesOpenedCount;
            set
            {
                _filesOpenedCount = value;
                this.RaisePropertyChanged();
            }
        }

        public IOutlookBarItemViewModel SelectedOutlookBarItemViewModel
        {
            get => _selectedOutlookBarItemViewModel;
            set
            {
                _selectedOutlookBarItemViewModel = value;
                this.RaisePropertyChanged();
            }
        }

        public ObservableCollection<IOutlookBarItemViewModel> OutlookBarItemViewModels { get; set; }

        #endregion

        #region Commands

        #region CloseAllFileReferencesCommand

        public DelegateCommand<IEnumerable<IOutlookBarItemViewModel>> CloseAllFileReferencesCommand { get; set; }

        private void OnCloseAllFileReferences(IEnumerable<IOutlookBarItemViewModel> models)
        {
            models.EnsureNotNull();

            foreach (var fileReferenceId in models.Select(p => p.FileReferenceId))
            {
                var item = _searchViewModel.SearchListItemViewModels.SingleOrDefault(p => p.FileReferenceId == fileReferenceId);
                //item?.MarkFileOpenedAs(false);
            }

            CloseAllFiles();
            UpdateFilesOpenedCount();
            RefreshCommands();
        }

        private static bool CanCloseAllFileReferences(IEnumerable<IOutlookBarItemViewModel> models)
        {
            return models?.Any() == true;
        }

        #endregion

        #endregion

        #region Methods

        private void Initialize()
        {
            _cleanup = new CompositeDisposable();

            OutlookBarItemViewModels = new ObservableCollection<IOutlookBarItemViewModel>();

            InitializeCommands();

            _searchViewModel.LoadFileReferenceCommand
                            .Subscribe(fileReference => LoadFileReference(fileReference))
                            .DisposeWith(_cleanup);

            //var shared = _searchViewModel.SearchTermConnectable.ToObservableChangeSet();

            //shared.WhenPropertyChanged(p => p.IsOpened, false)
            //.SubscribeOn(RxApp.TaskpoolScheduler)
            //.ObserveOn(RxApp.MainThreadScheduler)
            //.Subscribe(propertyValue => LoadFile(propertyValue))
            //.DisposeWith(_cleanup);

            //_searchViewModel.SearchTermConnectable.Connect();
        }

        private void InitializeCommands()
        {
            CloseAllFileReferencesCommand = new DelegateCommand<IEnumerable<IOutlookBarItemViewModel>>(OnCloseAllFileReferences, CanCloseAllFileReferences);
        }

        private void RefreshCommands()
        {
            CloseAllFileReferencesCommand.RaiseCanExecuteChanged();
        }

        private void UpdateFilesOpenedCount()
        {
            FilesOpenedCount = OutlookBarItemViewModels.Count;
        }

        private void CloseAllFiles()
        {
            OutlookBarItemViewModels.Clear();
        }

        private void LoadFile([NotNull] PropertyValue<FileReferenceListItemViewModel, bool> propertyValue)
        {
            switch (propertyValue?.Value)
            {
                case true:
                    LoadFileReference(propertyValue.Sender.FileReference);
                    break;
                default:
                    UnloadFileReference(propertyValue.Sender.FileReference);
                    break;
            }
        }

        public void LoadFileReference([NotNull] IFileReference fileReference)
        {
            fileReference.EnsureNotNull();

            var model = _modelFactory.Create<IOutlookBarItemViewModel>(fileReference, this);
            OutlookBarItemViewModels.Add(model);
            SelectedOutlookBarItemViewModel = OutlookBarItemViewModels.FirstOrDefault();

            RefreshCommands();
        }

        public void UnloadFileReference([NotNull] IFileReference fileReference)
        {
            _cachingService.Remove(fileReference.FileReferenceId, CacheRegions.FileReferences);
            OutlookBarItemViewModels.RemoveWhere(p => p.FileReferenceId == fileReference.FileReferenceId);
        }

        private void ShowStatusBarMessage(string message = null)
        {
            _statusBarMessageQueue.QueueMessage(message);
        }

        public void Dispose()
        {
            _cleanup?.Dispose();
        }

        public void OnImportsSatisfied()
        {
        }

        #endregion
    }
}
