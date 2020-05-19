using Prism.Mef;
using System;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Windows;
using TheFund.AtidsXe.Modules.Administration;
using TheFund.AtidsXe.Modules.ApplicationStatus;
using TheFund.AtidsXe.Modules.Common;
using TheFund.AtidsXe.Modules.Navigation;
using TheFund.AtidsXe.Modules.Search;
using TheFund.AtidsXe.Modules.Services;
using TheFund.AtidsXe.Modules.Shared;
using TheFund.AtidsXe.Modules.WorkSpace;
using TheFund.AtidsXe.Wpf.ViewModels;
using TheFund.AtidsXe.Wpf.Views;

namespace TheFund.AtidsXe.Wpf
{
    public class Bootstrapper : MefBootstrapper
    {
        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            AddAssemblyCatalog(typeof(AdministrationModule).Assembly);
            AddAssemblyCatalog(typeof(ShellViewModel).Assembly);
            AddAssemblyCatalog(typeof(NavigationModule).Assembly);
            AddAssemblyCatalog(typeof(SearchModule).Assembly);
            AddAssemblyCatalog(typeof(ServicesModule).Assembly);
            AddAssemblyCatalog(typeof(SharedModule).Assembly);
            AddAssemblyCatalog(typeof(WorkSpaceModule).Assembly);
            AddAssemblyCatalog(typeof(ApplicationStatusModule).Assembly);
            AddAssemblyCatalog(typeof(CommonModule).Assembly);
        }

        private void AddAssemblyCatalog(Assembly assembly)
        {
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(assembly));
        }

        protected override void InitializeShell()
        {
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            //Application.Current.MainWindow.Closed += LoginView_Closed;
            Application.Current.MainWindow.Show();
        }

        private void LoginView_Closed(object sender, EventArgs e)
        {
            //Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
            //Shell = Container.GetExportedValue<IShellView>() as ShellView;
            //Application.Current.MainWindow = (ShellView)Shell;
            //Application.Current.MainWindow.Show();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.GetExportedValue<IShellView>() as ShellView;
        }
    }
}
