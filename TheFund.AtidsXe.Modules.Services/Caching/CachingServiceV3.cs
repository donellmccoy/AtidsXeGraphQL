using CacheManager.Core;
using CacheManager.Core.Internal;
using DynamicData;
using Ensure;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.Modules.Services.Caching
{
    [Export(typeof(ICachingServiceV3))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public sealed class CachingServiceV3 : ReactiveObject, ICachingServiceV3
    {
        #region Fields

        private readonly ICacheManager<object> _cacheManager;
        private Dictionary<string, int> _cacheRegions;
        private int _itemsCountTotal;
        private readonly SourceList<(string, string)> _items = new SourceList<(string, string)>();

        #endregion

        #region Constructors

        public CachingServiceV3()
        {
            _cacheRegions = new Dictionary<string, int>();
            _cacheManager = CacheFactory.Build("GraphQLCache", settings =>
            {
                settings.WithSystemRuntimeCacheHandle("atidsxe")
                        .WithExpiration(ExpirationMode.Sliding, new TimeSpan(10, 0, 0));
            });

            _cacheManager.OnAdd += OnAdd;
            _cacheManager.OnClearRegion += OnClearRegion;
            _cacheManager.OnRemove += OnRemove;
        }

        #endregion

        #region Properties

        public IObservableCache<string, int> All { get; }

        public Dictionary<string, int> CacheRegions
        {
            get => _cacheRegions;
            set => this.RaiseAndSetIfChanged(ref _cacheRegions, value);
        }

        public int ItemsCountTotal
        {
            get => _itemsCountTotal;
            set => this.RaiseAndSetIfChanged(ref _itemsCountTotal, value);
        }

        #endregion

        #region Methods

        public IObservable<IChangeSet<(string, string)>> Connect()
        {
            return _items.Connect();
        }

        public void ClearRegion(string region)
        {
            region.EnsureNotNullOrWhitespace();
            ThrowIfRegionNotRegistered(region);

            _cacheManager.ClearRegion(region);
        }

        public void RemoveItem(string key, string region)
        {
            key.EnsureNotNullOrWhitespace();
            region.EnsureNotNullOrWhitespace();

            ThrowIfRegionNotRegistered(region);

            if (_cacheManager.Exists(key, region))
            {
                _cacheManager.Remove(key, region);
            }
        }

        public void RemoveItem(int key, string region)
        {
            region.EnsureNotNullOrWhitespace();
            RemoveItem(key.ToString(), region);
        }

        public IObservable<Unit> RemoveItemObservable(int key, string region)
        {
            region.EnsureNotNullOrWhitespace();
            return Observable.Start(() =>
            {
                RemoveItem(key.ToString(), region);
            });
        }

        public void RemoveItems(IEnumerable<int> keys, string region)
        {
            keys.EnsureNotNull();
            region.EnsureNotNull();

            if (!keys.Any())
            {
                throw new ArgumentException("Keys collection cannot be empty", nameof(keys));
            }

            foreach (var key in keys)
            {
                RemoveItem(key.ToString(), region);
            }
        }

        public void RemoveItems(IEnumerable<string> keys, string region)
        {
            keys.EnsureNotNull();
            region.EnsureNotNull();

            if (!keys.Any())
            {
                throw new ArgumentException("Keys collection cannot be empty", nameof(keys));
            }

            if (keys.Any(p => p == null))
            {
                throw new ArgumentNullException(nameof(keys), "All keys must non-null");
            }

            foreach (var key in keys)
            {
                RemoveItem(key, region);
            }
        }

        public void RemoveItems(string region, params string[] keys)
        {
            keys.EnsureNotNull();
            region.EnsureNotNull();

            if (!keys.Any())
            {
                throw new ArgumentException("Keys collection cannot be empty", nameof(keys));
            }

            if (keys.Any(p => p == null))
            {
                throw new ArgumentNullException(nameof(keys), "All keys must be non-null");
            }

            foreach (var key in keys)
            {
                RemoveItem(key, region);
            }
        }

        public void RemoveItems(string region, params int[] keys)
        {
            keys.EnsureNotNull();
            region.EnsureNotNull();

            if (!keys.Any())
            {
                throw new ArgumentException("Keys collection cannot be empty", nameof(keys));
            }

            foreach (var key in keys)
            {
                RemoveItem(key, region);
            }
        }

        public void AddOrUpdate(string key, object value, string region)
        {
            _cacheManager.AddOrUpdate(key, region, value, o => o);
        }

        public void AddItem(Func<string, Task<string>> func)
        {

        }

        public void AddItem(string key, object value, string region)
        {
            key.EnsureNotNullOrWhitespace();
            value.EnsureNotNull();
            region.EnsureNotNullOrWhitespace();

            ThrowIfRegionNotRegistered(region);

            if (!_cacheManager.Exists(key, region))
            {
                _cacheManager.Add(key, value, region);
            }
        }

        public void AddItem(int key, object value, string region)
        {
            AddItem(key.ToString(), value, region);
        }

        public bool IsCached(string key, string region)
        {
            key.EnsureNotNullOrWhitespace();
            region.EnsureNotNullOrWhitespace();

            ThrowIfRegionNotRegistered(region);

            return _cacheManager.Exists(key, region);
        }

        public bool IsCached(int key, string region)
        {
            region.EnsureNotNullOrWhitespace();

            ThrowIfRegionNotRegistered(region);

            return IsCached(key.ToString(), region);
        }

        public async Task<object> TryGetOrAddItemAsync(string key, string region, Task<Func<string, string, string>> valueFactory)
        {
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(key))
            {
                return null;
            }

            object value = null;

            if (!_cacheManager.TryGetOrAdd(key, region, await valueFactory, out value))
            {
                value = await valueFactory;
            }

            return value;
        }

        public TOut GetItem<TOut>(string key, string region)
        {
            key.EnsureNotNullOrWhitespace();
            region.EnsureNotNullOrWhitespace();

            ThrowIfRegionNotRegistered(region);

            return _cacheManager.Exists(key, region) ?
                   _cacheManager.Get<TOut>(key, region) : default;
        }

        public TOut GetItem<TOut>(int key, string region)
        {
            region.EnsureNotNullOrWhitespace();

            return GetItem<TOut>(key.ToString(), region);
        }

        public int GetRegionItemsCount(string region)
        {
            region.EnsureNotNullOrWhitespace();
            ThrowIfRegionNotRegistered(region);

            return _cacheRegions.Single(p => p.Key == region).Value;
        }

        public void RegisterCacheRegions(params string[] regions)
        {
            regions.EnsureNotNull();

            if (!regions.Any())
            {
                throw new ArgumentException("Regions collection cannot be empty", nameof(regions));
            }

            foreach (var region in regions)
            {
                if (!_cacheRegions.ContainsKey(region))
                {
                    _cacheRegions.Add(region, 0);
                }
            }
        }

        public bool RegionItemsCountLessThen(string region, int limit)
        {
            region.EnsureNotNullOrWhitespace();

            return GetRegionItemsCount(region) < limit;
        }

        private void UpdateItemsCountTotal()
        {
            ItemsCountTotal = _cacheRegions.Values.Sum();
        }

        private void OnClearRegion(object sender, CacheClearRegionEventArgs e)
        {
            _cacheRegions[e.Region] = 0;
            UpdateItemsCountTotal();
        }

        private void OnRemove(object sender, CacheActionEventArgs e)
        {
            _cacheRegions[e.Region]--;

            _items.Remove((e.Key, e.Region));

            UpdateItemsCountTotal();
        }

        private void OnAdd(object sender, CacheActionEventArgs e)
        {
            _cacheRegions[e.Region]++;

            _items.Add((e.Key, e.Region));

            UpdateItemsCountTotal();
        }

        private void ThrowIfRegionNotRegistered(string region)
        {
            if (!_cacheRegions.ContainsKey(region))
            {
                throw new ArgumentException($"Region: {region} is not registered.");
            }
        }

        #endregion
    }
}
