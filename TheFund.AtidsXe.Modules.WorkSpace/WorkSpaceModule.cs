using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.WorkSpace.Views;

namespace TheFund.AtidsXe.Modules.WorkSpace
{
    [ModuleExport(nameof(WorkSpaceModule), typeof(WorkSpaceModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class WorkSpaceModule : IModule
    {
        [Import]
        public IRegionManager RegionManager;

        public void Initialize()
        {
            RegionManager.RegisterViewWithRegion("WorkspaceRegion", typeof(IWorkspaceView));
        }
    }
}
