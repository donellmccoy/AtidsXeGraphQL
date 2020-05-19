using Prism.Events;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.ViewModels;

namespace TheFund.AtidsXe.Modules.WorkSpace.ViewModels
{
    [Export(typeof(ITitleEventViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class TitleEventViewModel : ViewModelBase, ITitleEventViewModel
    {
        [ImportingConstructor]
        public TitleEventViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {

        }
    }
}
