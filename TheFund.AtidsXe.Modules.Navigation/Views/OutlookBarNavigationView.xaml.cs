using System.ComponentModel.Composition;
using System.Windows.Controls;
using TheFund.AtidsXe.Modules.Navigation.ViewModels;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;

namespace TheFund.AtidsXe.Modules.Navigation.Views
{
    [Export(typeof(IOutlookBarNavigationView))]
    public partial class OutlookBarNavigationView : UserControl, IOutlookBarNavigationView
    {
        public OutlookBarNavigationView()
        {
            InitializeComponent();
        }

        [Import(typeof(IOutlookBarViewModel))]
        private IOutlookBarViewModel NavigationViewModel
        {
            set => DataContext = value;
        }
    }
}
