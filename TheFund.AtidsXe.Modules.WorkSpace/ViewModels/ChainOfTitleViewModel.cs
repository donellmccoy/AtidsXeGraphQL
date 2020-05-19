using Prism.Events;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.ViewModels;

namespace TheFund.AtidsXe.Modules.WorkSpace.ViewModels
{
    [Export(typeof(IChainOfTitleViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ChainOfTitleViewModel : ViewModelBase, IChainOfTitleViewModel
    {
        [ImportingConstructor]
        public ChainOfTitleViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {

        }
    }
}