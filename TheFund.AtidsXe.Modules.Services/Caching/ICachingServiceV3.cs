using DynamicData;
using System;
using System.Collections.Generic;
using System.Reactive;

namespace TheFund.AtidsXe.Modules.Services.Caching
{
    public interface ICachingServiceV3
    {
        void RemoveItem(string key, string region);
        void AddItem(string key, object value, string region);
        void AddItem(int key, object value, string region);
        int GetRegionItemsCount(string region);
        bool IsCached(string key, string region);
        bool IsCached(int key, string region);
        TOut GetItem<TOut>(string key, string region);
        TOut GetItem<TOut>(int key, string region);
        void RemoveItem(int key, string region);
        void ClearRegion(string region);
        void RemoveItems(IEnumerable<int> keys, string region);
        void RemoveItems(IEnumerable<string> keys, string region);
        void RemoveItems(string region, params string[] keys);
        void RemoveItems(string region, params int[] keys);
        bool RegionItemsCountLessThen(string region, int limit);
        //Dictionary<string, int> CacheRegions { get; set; }
        int ItemsCountTotal { get; set; }
        void RegisterCacheRegions(params string[] regions);
        IObservable<Unit> RemoveItemObservable(int key, string region);
        IObservable<IChangeSet<(string, string)>> Connect();
    }
}