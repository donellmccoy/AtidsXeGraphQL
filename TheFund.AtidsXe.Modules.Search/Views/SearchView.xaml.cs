using MaterialDesignThemes.Wpf;
using ReactiveUI;
using System.ComponentModel.Composition;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Input;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using TheFund.AtidsXe.Modules.Search.ViewModels;

namespace TheFund.AtidsXe.Modules.Search.Views
{
    [Export(typeof(ISearchView))]
    public partial class SearchView : SearchViewBase, ISearchView
    {
        public SearchView()
        {
            InitializeComponent();

            ViewModel = new SearchViewModel();
        }

        [ImportingConstructor]
        public SearchView(ISearchViewModel model)
        {
            InitializeComponent();

            ViewModel = model as SearchViewModel;
            
            this.WhenActivated(compositeDisposable =>
            {
                this.Bind(
                        ViewModel,
                        viewModel => viewModel.SelectedFileReferenceListItemViewModel,
                        view => view.SearchResultsRadGridView.SelectedItem)
                    .DisposeWith(compositeDisposable);

                this.BindCommand(
                        ViewModel,
                        viewModel => viewModel.LoadFileReferenceCommand,
                        view => view.SearchResultsRadGridView,
                        viewModel => viewModel.SelectedFileReferenceListItemViewModel,
                        nameof(SearchResultsRadGridView.MouseDoubleClick))
                    .DisposeWith(compositeDisposable);

                this.OneWayBind(
                        ViewModel,
                        viewModel => viewModel.SearchListItemViewModels,
                        view => view.SearchResultsRadGridView.ItemsSource)
                    .DisposeWith(compositeDisposable);

                this.OneWayBind(
						ViewModel,
						viewModel => viewModel.FavoriteListItemViewModels,
						view => view.FavoritesResultsRadGridView.ItemsSource)
					.DisposeWith(compositeDisposable);

                this.OneWayBind(
						ViewModel,
						viewModel => viewModel.IsBusy,
						view => view.SearchProgressBar.IsIndeterminate)
					.DisposeWith(compositeDisposable);

				this.OneWayBind(
						ViewModel,
						viewModel => viewModel.IsBusy,
						view => view.SearchProgressBar.Visibility, BooleanToHiddenConverter)
					.DisposeWith(compositeDisposable);

				this.Bind(
                        ViewModel,
                        viewModel => viewModel.SearchTerm,
                        view => view.SearchRadComboBox.Text)
                    .DisposeWith(compositeDisposable);

                this.OneWayBind(
                        ViewModel,
                        viewModel => viewModel.RecentSearchTerms,
                        view => view.SearchRadComboBox.ItemsSource)
                    .DisposeWith(compositeDisposable);

                this.OneWayBind(
                        ViewModel,
                        viewModel => viewModel.SearchResultsCount,
                        view => view.TotalNumberOfFilesCountLabel.Content)
                    .DisposeWith(compositeDisposable);

                //View to View binding
                //this.WhenAnyValue(x => x.TemplateLabel.ActualWidth)
                //    .BindTo(this, view => view.FilterLabel.Width)
                //    .DisposeWith(disposable);
            });

            Loaded += OnLoaded;
        }

        private static Visibility BooleanToHiddenConverter(bool value) => value ? Visibility.Visible : Visibility.Hidden;

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(SearchRadComboBox);
            SearchRadComboBox.Focus();
        }

        private void SearchResultsRadGridView_RadContextMenu_OnOpened(object sender, RoutedEventArgs e) => OnGridViewContextMenuOpended(sender, e);

        private void OnGridViewContextMenuOpended(object sender, RoutedEventArgs e) => SelectGridViewRow(((RadContextMenu)sender).GetClickedElement<GridViewRow>());

        private void AddRemoveFavoritesButton_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e) => ExecutePreviewMouseDoubleClick(sender, e);

        private void PopupBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e) => ExecutePreviewMouseDoubleClick(sender, e);

        private static void ExecutePreviewMouseDoubleClick(object sender, MouseButtonEventArgs e) => e.Handled = e.Source.Equals(sender);

        private void SearchResultsRadGridView_PopupBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => SelectGridViewRow(SearchResultsRadGridView.GetRowForItem(((PopupBox)sender).DataContext));

        private void FavoritesResultsRadGridView_PopupBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => SelectGridViewRow(FavoritesResultsRadGridView.GetRowForItem(((PopupBox)sender).DataContext));

        private void RecentsResultsRadGridView_PopupBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => SelectGridViewRow(RecentsResultsRadGridView.GetRowForItem(((PopupBox)sender).DataContext));

        private static void SelectGridViewRow(GridViewRow row)
        {
            if (row != null)
            {
                row.IsSelected = row.IsCurrent = true;
            }
        }
    }
}
