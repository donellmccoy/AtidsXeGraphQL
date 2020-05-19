using System.ComponentModel.Composition;
using JetBrains.Annotations;
using Telerik.Windows.Controls;
using TheFund.AtidsXe.Modules.Navigation.ViewModels;

namespace TheFund.AtidsXe.Modules.Navigation.Views
{
    [Export(typeof(INavigationView))]
    public partial class NavigationView : INavigationView
    {
        public NavigationView()
        {
            InitializeComponent();
            StyleManager.SetTheme(NavigationTreeView, new Windows8Theme());
        }

        [UsedImplicitly]
        [Import(typeof(IOutlookBarViewModel))]
        private IOutlookBarViewModel NavigationViewModel
        {
            set => DataContext = value;
        }
    }
}
