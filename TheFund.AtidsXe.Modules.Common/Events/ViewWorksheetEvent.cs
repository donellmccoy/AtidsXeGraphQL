using Prism.Events;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Common.Events
{
    public class ViewWorksheetEvent : PubSubEvent<IFileReference>
    {
    }
}