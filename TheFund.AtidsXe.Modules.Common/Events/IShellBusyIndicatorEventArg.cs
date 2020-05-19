using System.Threading;

namespace TheFund.AtidsXe.Modules.Common.Events
{
    public interface IShellBusyIndicatorEventArg
    {
        string Message { get; set; }
        int Delay { get; set; }
        CancellationToken CancellationToken { get; set; }
    }
}