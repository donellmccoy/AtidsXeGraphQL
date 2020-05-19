using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;

namespace TheFund.AtidsXe.Modules.Administration
{
    [ModuleExport(nameof(AdministrationModule), typeof(AdministrationModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class AdministrationModule : IModule
    {
        [Import]
        public IRegionManager RegionManager;

        public void Initialize()
        {
        }
    }
}
