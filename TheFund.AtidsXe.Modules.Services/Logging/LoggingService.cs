using JetBrains.Annotations;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.Modules.Services.Logging
{
    [Export(typeof(ILoggingService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class LoggingService : ILoggingService
    {
        public async Task LogEntryAsync([NotNull] string message)
        {
            await Task.Delay(1);
            Debug.WriteLine(message);
        }

        public IObservable<Unit> LogEntryObservable([NotNull] string message)
        {
            return Observable.FromAsync(_ => LogEntryAsync(message));
        }
    }
}
