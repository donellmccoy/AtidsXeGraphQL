using System.ComponentModel.Composition;
using System.Windows.Controls;
using TheFund.AtidsXe.Modules.UserProjects.ViewModels;

namespace TheFund.AtidsXe.Modules.UserProjects.Views
{
    [Export(typeof(IUserProjectsView))]
    public partial class UserProjectsView : UserControl, IUserProjectsView
    {
        public UserProjectsView()
        {
            InitializeComponent();
        }

        [Import(typeof(IUserProjectsViewModel))]
        private IUserProjectsViewModel ViewModel
        {
            set => DataContext = value;
        }
}
}
