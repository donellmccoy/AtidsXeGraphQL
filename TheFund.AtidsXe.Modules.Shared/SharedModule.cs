using Prism.Mef.Modularity;
using Prism.Modularity;

namespace TheFund.AtidsXe.Modules.Shared
{
    [ModuleExport(nameof(SharedModule), typeof(SharedModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class SharedModule : IModule
    {
        public void Initialize()
        {
            
        }
    }
}
