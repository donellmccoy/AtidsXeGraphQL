using Ensure;
using JetBrains.Annotations;
using Prism.Commands;
using Prism.Events;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Common.Extensions;
using TheFund.AtidsXe.Modules.Navigation.Factories;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.ChainOfTitles;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.Names;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.Policies;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.Properties;
using TheFund.AtidsXe.Modules.Search.ViewModels;

namespace TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar
{
    [Export(typeof(IOutlookBarItemViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed class OutlookBarItemViewModel : ReactiveObject, IOutlookBarItemViewModel
    {
        #region Fields

        private readonly IEventAggregator _eventAggregator;
        private readonly IGroupTreeViewModelFactory _modelFactory;
        private readonly ISearchViewModel _searchViewModel;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public OutlookBarItemViewModel(IEventAggregator eventAggregator,
            ISearchViewModel searchViewModel,
            IGroupTreeViewModelFactory modelFactory)
        {
            _eventAggregator = eventAggregator;
            _searchViewModel = searchViewModel;
            _modelFactory = modelFactory;
            Initialize();
        }

        #endregion

        #region Properties

        public string Header => $"{FileReferenceName}";

        public string ImageSourcePath { get; set; }

        public int FileReferenceId => FileReference.FileReferenceId;

        public string FileReferenceName => FileReference.FileReferenceName;

        public IFileReference FileReference { get; set; }

        public IOutlookBarViewModel Parent { get; set; }

        public ObservableCollection<INavigationGroupTreeViewModel> NavigationGroupViewModels { get; set; }

        #endregion

        #region Commands

        #region PreviewSelectionChangedCommand

        public DelegateCommand<object> PreviewSelectionChangedCommand { get; set; }

        private void OnPreviewSelectionChanged(object args)
        {

        }

        private bool CanPreviewSelectionChange(object args)
        {
            return true;
        }

        #endregion

        #region SelectionChangedCommand

        public DelegateCommand<object> SelectionChangedCommand { get; set; }

        private void OnSelectionChanged(object args)
        {

        }

        private bool CanSelectionChange(object args)
        {
            return true;
        }

        #endregion

        #region CloseFileReferenceCommand

        public DelegateCommand<IOutlookBarItemViewModel> CloseFileReferenceCommand { get; set; }

        private void OnCloseFileReference(IOutlookBarItemViewModel model)
        {
            model.EnsureNotNull();
            Parent.UnloadFileReference(model.FileReference);
        }

        private static bool CanCloseFileReference(IOutlookBarItemViewModel model)
        {
            return true;
        }

        #endregion

        #endregion

        #region Methods

        private void Initialize()
        {
            NavigationGroupViewModels = new ObservableCollection<INavigationGroupTreeViewModel>();
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            PreviewSelectionChangedCommand = new DelegateCommand<object>(OnPreviewSelectionChanged, CanPreviewSelectionChange);
            SelectionChangedCommand = new DelegateCommand<object>(OnSelectionChanged, CanSelectionChange);
            CloseFileReferenceCommand = new DelegateCommand<IOutlookBarItemViewModel>(OnCloseFileReference, CanCloseFileReference);
        }

        public void Build([NotNull] IFileReference fileReference, [NotNull] IOutlookBarViewModel parent)
        {
            fileReference.EnsureNotNull();
            parent.EnsureNotNull();

            FileReference = fileReference;
            Parent = parent;

            if (!fileReference.HasSearches)
            {
                return;
            }

            AddGroupTreeViewModel<IPolicySearchGroupTreeViewModel>();
            AddGroupTreeViewModel<IPropertySearchGroupTreeViewModel>();
            AddGroupTreeViewModel<INameSearchGroupTreeViewModel>();
            AddGroupTreeViewModel<IChainOfTitleGroupTreeViewModel>();
        }

        private void AddGroupTreeViewModel<T>() where T : INavigationGroupTreeViewModel
        {
            NavigationGroupViewModels.Add(_modelFactory.Create<T>(FileReference, this));
        }

        #endregion
    }
}
