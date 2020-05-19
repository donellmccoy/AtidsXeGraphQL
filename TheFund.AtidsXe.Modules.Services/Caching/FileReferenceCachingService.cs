using DynamicData;
using DynamicData.Kernel;
using Nito.Comparers.Util;

using Ensure;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.Caching;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;
using TheFund.AtidsXe.Modules.Services.Factories;
using TheFund.AtidsXe.Modules.Services.Models;
using System.Reactive.Linq;

namespace TheFund.AtidsXe.Modules.Services.Caching
{
    [Export(typeof(IFileReferenceCachingService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class FileReferenceCachingService : IFileReferenceCachingService
    {
        private readonly SourceCache<IFileReference, string> _cache;

        public FileReferenceCachingService()
        {
            _cache = new SourceCache<IFileReference, string>(fileReference => fileReference.FileReferenceId.ToString());
        }

        public IObservable<IChangeSet<IFileReference, string>> Connect()
        {
            return _cache.Connect();
        }

        public void Clear()
        {
            _cache.Clear();
        }

        public bool IsCountLessThen(int maxCount)
        {
            return _cache.Count < maxCount;
        }

        public IObservable<Change<IFileReference, string>> Watch(int key)
        {
            return _cache.Watch(key.ToString());
        }

        public IObservable<IFileReference> WatchValue(int key)
        {
            return _cache.WatchValue(key.ToString());
        }

        public void Refresh()
        {
            _cache.Refresh();
        }

        public void RemoveKeys(IEnumerable<int> keys)
        {
            _cache.RemoveKeys(keys.Select(p => p.ToString()));
        }

        public void RemoveKeys(params int[] keys)
        {
            _cache.RemoveKeys(keys.Select(p => p.ToString()));
        }

        public void Refresh(IFileReference fileReference)
        {
            _cache.Refresh(fileReference);
        }

        public Optional<IFileReference> Lookup(int key)
        {
            return _cache.Lookup(key.ToString());
        }

        public bool IsCached(int key)
        {
            return _cache.Lookup(key.ToString()).HasValue;
        }

        public void AddOrUpdate(IFileReference fileReference)
        {
            _cache.AddOrUpdate(fileReference);
        }

        public void AddOrUpdate(IEnumerable<IFileReference> fileReferences)
        {
            _cache.Edit(innerList =>
            {
                innerList.Clear();
                innerList.AddOrUpdate(fileReferences);
            });
        }

        public async Task AddOrUpdateAsync(int key, Func<Task<IEnumerable<IFileReference>>> valueFactory)
        {
            var option = Lookup(key);
            if (!option.HasValue)
            {
                var fileReferences = await valueFactory();
                AddOrUpdate(fileReferences);
            }
            else
            {
                Refresh(option.Value);
            }
        }

        public async Task AddOrUpdateAsync(int key, Func<Task<IFileReference>> valueFactory)
        {
            var option = Lookup(key);
            if (!option.HasValue)
            {
                var fileReference = await valueFactory();
                AddOrUpdate(fileReference);
            }
            else
            {
                Refresh(option.Value);
            }
        }
    }
}
