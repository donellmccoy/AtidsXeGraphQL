using JetBrains.Annotations;
using Microsoft.Practices.ServiceLocation;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Navigation.ViewModels;
using TheFund.AtidsXe.Modules.Navigation.ViewModels.OutlookBar;

namespace TheFund.AtidsXe.Modules.Navigation.Factories
{
    [Export(typeof(IGroupTreeViewModelFactory))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class GroupTreeViewModelFactory : IGroupTreeViewModelFactory
    {
        public T Create<T>([NotNull] IFileReference fileReference, [NotNull] IOutlookBarItemViewModel parent)
            where T : INavigationGroupTreeViewModel
        {
            var model = ServiceLocator.Current.GetInstance<T>();
            model.Build(fileReference, parent);
            return model;
        }
    }
}
