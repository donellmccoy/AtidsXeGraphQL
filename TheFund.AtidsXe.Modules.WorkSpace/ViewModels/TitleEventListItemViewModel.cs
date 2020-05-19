using Prism.Events;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.ViewModels;

namespace TheFund.AtidsXe.Modules.WorkSpace.ViewModels
{
    [Export(typeof(ITitleEventListItemViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TitleEventListItemViewModel : ViewModelBase, ITitleEventListItemViewModel
    {
        [ImportingConstructor]
        public TitleEventListItemViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {

        }
    }
}
