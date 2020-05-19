using System.Reactive.Concurrency;

namespace TheFund.AtidsXe.Modules.Common.Providers
{
    public interface ISchedulerProvider
    {
        IScheduler MainThread { get; }
        IScheduler Background { get; }
    }
}