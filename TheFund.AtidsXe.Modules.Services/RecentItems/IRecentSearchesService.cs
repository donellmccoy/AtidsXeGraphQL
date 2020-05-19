using DynamicData;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.Modules.Services.RecentItems
{
    public interface IRecentSearchesService
    {
        IObservableList<string> RecentSearchTerms { get; } 
        Task<string> AddSearchTermAsync(string searchTerm, CancellationToken token = default);
        IObservable<IChangeSet<string>> Connect();
    }
}