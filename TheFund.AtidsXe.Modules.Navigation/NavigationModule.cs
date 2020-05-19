using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.Constants;
using TheFund.AtidsXe.Modules.Navigation.Views;

namespace TheFund.AtidsXe.Modules.Navigation
{
    [ModuleExport(nameof(NavigationModule), typeof(NavigationModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class NavigationModule : IModule
    {
        [Import]
        public IRegionManager RegionManager;

        public void Initialize()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(IOutlookBarNavigationView));
        }
    }
}
