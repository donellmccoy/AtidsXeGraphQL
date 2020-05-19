using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.ApplicationStatus.Views;
using TheFund.AtidsXe.Modules.Common.Constants;

namespace TheFund.AtidsXe.Modules.ApplicationStatus
{
    [ModuleExport(nameof(ApplicationStatusModule), typeof(ApplicationStatusModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class ApplicationStatusModule : IModule
    {
        [Import]
        public IRegionManager RegionManager;

        public void Initialize()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.ApplicationStatusRegion, typeof(IStatusBarView));
        }
    }
}
