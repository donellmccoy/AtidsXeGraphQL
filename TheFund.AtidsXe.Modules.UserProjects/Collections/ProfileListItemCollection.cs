using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Telerik.Windows.Data;
using TheFund.AtidsXe.Modules.Common.Extensions;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.UserProjects.Collections
{
    public sealed class ProfileListItemCollection : RadObservableCollection<IProfileListItem>, IProfileListItemCollection
    {
        public void UnloadAll()
        {
            this.ForEach(p => p.IsLoaded = false);
        }

        public IObservable<Unit> SetAllNotLoaded()
        {
            return Observable.Start(() =>
            {
                this.ForEach(p => p.IsLoaded = false);
            });
        }

        public int ItemCount => Count;

        public bool HasItems => this.Any();

        public ProfileListItemCollection() : base()
        {

        }

        public ProfileListItemCollection(IEnumerable<IProfileListItem> items)
        {
            AddRange(items);
        }

        public IProfileListItem FirstItem()
        {
            return this.FirstOrDefault();
        }

        public void RemoveItem(IProfileListItem item)
        {
            Remove(item);
        }

        public void AddItems(IEnumerable<IProfileListItem> items, bool clear = true)
        {
            if (clear)
            {
                Clear();
            }
            AddRange(items);
        }
    }
}