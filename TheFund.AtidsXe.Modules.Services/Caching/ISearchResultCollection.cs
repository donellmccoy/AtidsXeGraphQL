using DynamicData;
using DynamicData.Kernel;
using System;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.Modules.Services.Caching
{
    public interface ISearchResultCollection
    {
        IObservableList<SearchInfo> Items { get; }
        void Add(SearchInfo searchResult);
        Task<SearchInfo> AddOrUpdate(string key, Func<Task<string>> valueFactory);
        IObservable<IChangeSet<SearchInfo>> Connect();
        SearchInfo Get(string key);
        void Remove(SearchInfo searchResult);
        void RemoveKey(string key);
        IObservable<Change<SearchInfo, string>> Watch(string key);
    }
}
