using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;

namespace TheFund.AtidsXe.Modules.UserProjects
{
    [ModuleExport(nameof(UserProjectsModule), typeof(UserProjectsModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class UserProjectsModule : IModule
    {
        [Import]
        public IRegionManager RegionManager;

        public void Initialize()
        {
            //RegionManager.RegisterViewWithRegion("UserProjectsRegion", typeof(IUserProjectsView));
        }
    }
}
