using Prism.Events;
using System.Collections.Generic;
using TheFund.AtidsXe.Modules.Common.Events.EventArguments;

namespace TheFund.AtidsXe.Modules.Common.Events.Search
{
    public sealed class FileReferencesClosedEvent : PubSubEvent<IFileReferencesClosedEventArgs>
    {
    }
}