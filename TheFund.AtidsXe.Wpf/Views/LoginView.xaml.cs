using System.ComponentModel.Composition;
using System.Windows;
using TheFund.AtidsXe.Wpf.ViewModels;

namespace TheFund.AtidsXe.Wpf.Views
{
    [Export(typeof(ILoginView))]
    public partial class LoginView : Window, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }

        [Import(typeof(ILoginViewModel))]
        private ILoginViewModel LoginViewModel
        {
            set => DataContext = value;
        }
    }
}
