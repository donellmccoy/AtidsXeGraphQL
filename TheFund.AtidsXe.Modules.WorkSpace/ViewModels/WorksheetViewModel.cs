using Prism.Events;
using System.ComponentModel.Composition;
using TheFund.AtidsXe.Modules.Common.ViewModels;

namespace TheFund.AtidsXe.Modules.WorkSpace.ViewModels
{
    [Export(typeof(IWorksheetViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorksheetViewModel : ViewModelBase, IWorksheetViewModel
    {
        [ImportingConstructor]
        public WorksheetViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {

        }

        public int FileReferenceId { get; set; }
    }
}