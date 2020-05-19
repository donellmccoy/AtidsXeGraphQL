using DynamicData;
using DynamicData.Kernel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Services.Models;

namespace TheFund.AtidsXe.Modules.Services.Caching
{
    public interface IFileReferenceCachingService
    {
        void AddOrUpdate(IFileReference item);
        bool IsCached(int key);
        bool IsCountLessThen(int maxCount);
        Optional<IFileReference> Lookup(int key);
        void Refresh();
        void Refresh(IFileReference item);
        void RemoveKeys(IEnumerable<int> keys);
        void Clear();
        IObservable<IChangeSet<IFileReference, string>> Connect();
        IObservable<Change<IFileReference, string>> Watch(int key);
        IObservable<IFileReference> WatchValue(int key);
        void RemoveKeys(params int[] keys);
        Task AddOrUpdateAsync(int key, Func<Task<IFileReference>> valueFactory);
        void AddOrUpdate(IEnumerable<IFileReference> fileReferences);
    }
}
