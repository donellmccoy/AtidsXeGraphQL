using Prism.Events;
using TheFund.AtidsXe.Modules.Common.Events.EventArguments;

namespace TheFund.AtidsXe.Modules.Common.Events.Status
{
    public sealed class StatusBarEvent : PubSubEvent<IStatusBarEventArgs>
    {
    }
}
