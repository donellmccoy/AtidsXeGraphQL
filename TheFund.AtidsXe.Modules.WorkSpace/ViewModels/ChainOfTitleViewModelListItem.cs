using Prism.Events;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.ViewModels;

namespace TheFund.AtidsXe.Modules.WorkSpace.ViewModels
{
    [Export(typeof(IChainOfTitleListItemViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ChainOfTitleListItemViewModel : ViewModelBase, IChainOfTitleListItemViewModel
    {
        [ImportingConstructor]
        public ChainOfTitleListItemViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {

        }
    }
}