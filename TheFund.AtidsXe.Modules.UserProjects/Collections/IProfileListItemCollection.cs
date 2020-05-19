using System;
using System.Collections.Generic;
using System.Reactive;
using TheFund.AtidsXe.Modules.Common.Models;

namespace TheFund.AtidsXe.Modules.UserProjects.Collections
{
    public interface IProfileListItemCollection
    {
        void UnloadAll();
        int ItemCount { get; }
        bool HasItems { get; }
        IProfileListItem FirstItem();
        void AddItems(IEnumerable<IProfileListItem> items, bool clear = true);
        void RemoveItem(IProfileListItem item);
        IObservable<Unit> SetAllNotLoaded();
    }
}