using JetBrains.Annotations;
using TheFund.AtidsXe.Modules.Common.Events.EventArguments;

namespace TheFund.AtidsXe.Modules.Common.Factories
{
    [UsedImplicitly]
    public class StatusBarEventArgFactory
    {
        public static IStatusBarEventArgs Create([NotNull] string status)
        {
            return new StatusBarEventArgs(status);
        }
    }
}