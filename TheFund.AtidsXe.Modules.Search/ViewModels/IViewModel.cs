using System;

namespace TheFund.AtidsXe.Modules.Search.ViewModels
{
    public interface IViewModel : IDisposable
    {
        bool IsBusy { get; }
        string BusyMessage { get; set; }
    }
}