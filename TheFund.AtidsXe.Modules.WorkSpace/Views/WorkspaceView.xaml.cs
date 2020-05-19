using System.ComponentModel.Composition;
using System.Windows.Controls;
using TheFund.AtidsXe.Modules.WorkSpace.ViewModels;

namespace TheFund.AtidsXe.Modules.WorkSpace.Views
{
    [Export(typeof(IWorkspaceView))]
    public partial class WorkspaceView : UserControl, IWorkspaceView
    {
        public WorkspaceView()
        {
            InitializeComponent();
        }

        [Import(typeof(IWorkspaceViewModel))]
        private IWorkspaceViewModel WorkspaceViewModel
        {
            set => DataContext = value;
        }
    }
}
