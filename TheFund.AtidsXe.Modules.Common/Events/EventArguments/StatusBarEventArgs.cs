using System;
using JetBrains.Annotations;

namespace TheFund.AtidsXe.Modules.Common.Events.EventArguments
{
    public sealed class StatusBarEventArgs : IStatusBarEventArgs
    {
        public string Status { get; }

        public StatusBarEventArgs([NotNull] string status)
        {
            Status = status ?? throw new ArgumentNullException(nameof(status));
        }
    }
}