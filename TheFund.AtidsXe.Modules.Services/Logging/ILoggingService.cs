using System;
using System.Reactive;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.Modules.Services.Logging
{
    public interface ILoggingService
    {
        Task LogEntryAsync(string message);
        IObservable<Unit> LogEntryObservable(string message);
    }
}