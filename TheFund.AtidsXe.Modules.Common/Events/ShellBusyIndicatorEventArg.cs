using System.Threading;

namespace TheFund.AtidsXe.Modules.Common.Events
{
    public sealed class ShellBusyIndicatorEventArg : IShellBusyIndicatorEventArg
    {
        public string Message { get; set; }

        public int Delay { get; set; }

        public CancellationToken CancellationToken { get; set; }
    }
}