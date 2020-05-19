using Prism.Events;
using TheFund.AtidsXe.Modules.Common.Events.EventArguments;

namespace TheFund.AtidsXe.Modules.Common.Events.Search
{
    public class OpenProfileEvent : PubSubEvent<IOpenProfileEventArgs>
    {
    }
}