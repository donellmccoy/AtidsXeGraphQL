using Prism.Mef.Modularity;
using Prism.Modularity;
using Prism.Regions;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.Constants;
using TheFund.AtidsXe.Modules.Search.Views;

namespace TheFund.AtidsXe.Modules.Search
{
    [ModuleExport(nameof(SearchModule), typeof(SearchModule), 
                    InitializationMode = InitializationMode.WhenAvailable, 
                    DependsOnModuleNames = new[] { "ApplicationStatusModule" })]
    public class SearchModule : IModule
    {
        [Import]
        public IRegionManager RegionManager;

        public void Initialize()
        {
            RegionManager.RegisterViewWithRegion(RegionNames.SearchRegion, typeof(ISearchView));
        }
    }
}
