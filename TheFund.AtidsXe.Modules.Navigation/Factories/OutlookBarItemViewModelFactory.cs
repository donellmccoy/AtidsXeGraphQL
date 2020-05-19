using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition;
using JetBrains.Annotations;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;

namespace TheFund.AtidsXe.Modules.Navigation.Factories
{
    [Export(typeof(IOutlookBarItemViewModelFactory))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    internal class OutlookBarItemViewModelFactory : IOutlookBarItemViewModelFactory
    {
        public T Create<T>([NotNull] IFileReference fileReference, [NotNull] IOutlookBarViewModel parent)
            where T : IOutlookBarItemViewModel
        {
            var model = ServiceLocator.Current.GetInstance<T>();
            model.Build(fileReference, parent);
            return model;
        }
    }
}
