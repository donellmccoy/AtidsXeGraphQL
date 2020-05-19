using System.ComponentModel.Composition;
using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;

namespace TheFund.AtidsXe.Modules.Common
{
    [ModuleExport(nameof(CommonModule), typeof(CommonModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class CommonModule : IModule
    {
        [Import]
        public IRegionManager RegionManager;

        public void Initialize()
        {
        }
    }
}
