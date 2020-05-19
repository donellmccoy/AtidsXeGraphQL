using Microsoft.Xaml.Behaviors;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace TheFund.AtidsXe.Modules.Common.Behaviors
{
    public sealed class EmptyDataTemplateBehavior : Behavior<RadGridView>
    {
        private readonly ContentPresenter ContentPresenter = new ContentPresenter();

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.LayoutUpdated += AssociatedObject_LayoutUpdated;
        }

        public DataTemplate EmptyDataTemplate { get; set; }

        private void AssociatedObject_LayoutUpdated(object sender, EventArgs e)
        {
            var rootGrid = AssociatedObject.ChildrenOfType<Grid>().FirstOrDefault();

            if (rootGrid != null)
            {
                AssociatedObject.LayoutUpdated -= AssociatedObject_LayoutUpdated;
                LoadTemplateIntoGridView(AssociatedObject);
                AssociatedObject.Items.CollectionChanged += Items_CollectionChanged;
                SetVisibility();
            }
        }

        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SetVisibility();
        }

        private void SetVisibility()
        {
            ContentPresenter.Visibility = AssociatedObject.Items.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }

        private void LoadTemplateIntoGridView(RadGridView gridView)
        {
            ContentPresenter.IsHitTestVisible = false;
            ContentPresenter.DataContext = this;
            ContentPresenter.ContentTemplate = EmptyDataTemplate;

            var rootGrid = gridView.ChildrenOfType<Grid>().FirstOrDefault();

            ContentPresenter.SetValue(Grid.RowProperty, 2);
            ContentPresenter.SetValue(Grid.RowSpanProperty, 2);
            ContentPresenter.SetValue(Grid.ColumnSpanProperty, 2);
            ContentPresenter.SetValue(FrameworkElement.MarginProperty, new Thickness(0, 27, 0, 0));

            rootGrid.Children.Add(ContentPresenter);
        }
    }
}
