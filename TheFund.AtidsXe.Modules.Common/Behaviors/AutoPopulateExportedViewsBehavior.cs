using System;
using System.ComponentModel.Composition;
using Prism.Regions;

namespace TheFund.AtidsXe.Modules.Common.Behaviors
{
    [Export(typeof(AutoPopulateExportedViewsBehavior))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AutoPopulateExportedViewsBehavior : RegionBehavior
    {
        protected override void OnAttach()
        {
            AddRegisteredViews();
        }

        public void OnImportsSatisfiedAsync()
        {
            AddRegisteredViews();
        }

        private void AddRegisteredViews()
        {
            if (Region == null)
            {
                return;
            }

            foreach (var viewEntry in RegisteredViews)
            {
                if (viewEntry.Metadata.RegionName != Region.Name)
                {
                    continue;
                }

                var view = viewEntry.Value;

                if (Region.Views.Contains(view))
                {
                    continue;
                }

                Region.Add(view);

                if (!viewEntry.Metadata.IsActiveOnStartUp)
                {
                    Region.Deactivate(view);
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "MEF injected values"), ImportMany(AllowRecomposition = true)]
        public Lazy<object, IViewRegionRegistration>[] RegisteredViews { get; set; }
    }
}
