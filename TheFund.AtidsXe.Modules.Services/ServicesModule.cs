using Prism.Mef.Modularity;
using Prism.Modularity;

namespace TheFund.AtidsXe.Modules.Services
{
    [ModuleExport(nameof(ServicesModule), typeof(ServicesModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class ServicesModule : IModule
    {
        public void Initialize()
        {
            
        }
    }
}
