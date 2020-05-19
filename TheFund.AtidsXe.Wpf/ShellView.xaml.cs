using System.ComponentModel.Composition;
using System.Windows;
using TheFund.AtidsXe.Wpf.ViewModels;

namespace TheFund.AtidsXe.Wpf
{
    [Export(typeof(IShellView))]
    public partial class ShellView : Window, IShellView
    {
        public ShellView()
        {
            InitializeComponent();
        }

        [Import(typeof(IShellViewModel))]
        private IShellViewModel ShellViewModel
        {
            set => DataContext = value;
        }
    }
}
