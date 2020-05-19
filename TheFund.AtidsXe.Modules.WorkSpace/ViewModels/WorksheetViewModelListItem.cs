using System.ComponentModel.Composition;

namespace TheFund.AtidsXe.Modules.WorkSpace.ViewModels
{
    [Export(typeof(IWorksheetViewModelListItem))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class WorksheetViewModelListItem : IWorksheetViewModelListItem
    {

    }
}