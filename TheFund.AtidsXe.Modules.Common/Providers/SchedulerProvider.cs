using System.Reactive.Concurrency;
using System.Windows.Threading;

namespace TheFund.AtidsXe.Modules.Common.Providers
{
    public class SchedulerProvider : ISchedulerProvider
    {
        public SchedulerProvider(Dispatcher dispatcher)
        {
            MainThread = new DispatcherScheduler(dispatcher);
        }

        public IScheduler MainThread { get; }
        public IScheduler Background => TaskPoolScheduler.Default;
    }
}
