// ***********************************************************************
// Assembly         : TheFund.AtidsXe.Modules.Common
// Author           : Donell McCoy
// Created          : 11-01-2019
//
// Last Modified By : Donell McCoy
// Last Modified On : 03-09-2020
// ***********************************************************************
// <copyright file="EnumerableExtensions.cs" company="Attorneys' Title Fund Services, LLC">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace TheFund.AtidsXe.Modules.Common.Extensions
{
    /// <summary>
    /// Class EnumerableExtensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        public static bool SafeAny<T>(this IEnumerable<T> source)
        {
            return source?.Any() == true;
        }

        /// <summary>
        /// Fors the each.
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="dict">The dictionary.</param>
        /// <param name="itemAction">The item action.</param>
        /// <exception cref="ArgumentNullException">dict</exception>
        public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> dict, Action<TKey, TValue> itemAction)
        {
            if (dict == null)
                throw new ArgumentNullException(nameof(dict));

            foreach (var kvp in dict)
            {
                itemAction(kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// Whens the specified condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="fn">The function.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        /// <exception cref="ArgumentNullException">
        /// list
        /// or
        /// condition
        /// or
        /// fn
        /// </exception>
        public static IQueryable<T> When<T>(this IQueryable<T> list, Func<bool> condition, Func<IQueryable<T>, IQueryable<T>> fn)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            if (fn == null)
                throw new ArgumentNullException(nameof(fn));

            return condition() ? fn(list) : list;
        }

        /// <summary>
        /// Whens the specified condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="fn">The function.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        /// <exception cref="ArgumentNullException">
        /// list
        /// or
        /// condition
        /// or
        /// fn
        /// </exception>
        public static IEnumerable<T> When<T>(this IEnumerable<T> list, Func<bool> condition, Func<IEnumerable<T>, IEnumerable<T>> fn)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            if (fn == null)
                throw new ArgumentNullException(nameof(fn));

            return condition() ? fn(list) : list;
        }

        /// <summary>
        /// Adds the when.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="value">The value.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        /// <exception cref="ArgumentNullException">list</exception>
        public static IList<T> AddWhen<T>(this IList<T> list, bool condition, T value)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (condition)
                list.Add(value);

            return list;
        }
        /// <summary>
        /// Adds the when.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="condition">The condition.</param>
        /// <param name="value">The value.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        /// <exception cref="ArgumentNullException">
        /// list
        /// or
        /// condition
        /// or
        /// value
        /// </exception>
        public static IList<T> AddWhen<T>(this IList<T> list, Func<bool> condition, Func<T> value)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            if (condition == null)
                throw new ArgumentNullException(nameof(condition));

            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (condition())
                list.Add(value());

            return list;
        }

        /// <summary>
        /// Maximums the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        /// <exception cref="ArgumentNullException">
        /// items
        /// or
        /// value
        /// </exception>
        [Pure, CanBeNull]
        public static T MaxItem<T>([NotNull] this IEnumerable<T> items, [NotNull] Func<T, float> value)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var bestScore = float.NegativeInfinity;
            var best = default(T);

            foreach (var item in items)
            {
                var s = value(item);
                if (s > bestScore)
                {
                    bestScore = s;
                    best = item;
                }
            }

            return best;
        }

        /// <summary>
        /// Minimums the item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="value">The value.</param>
        /// <returns>T.</returns>
        /// <exception cref="ArgumentNullException">
        /// items
        /// or
        /// value
        /// </exception>
        [Pure, CanBeNull]
        public static T MinItem<T>([NotNull] this IEnumerable<T> items, [NotNull] Func<T, float> value)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return items.MaxItem(a => -value(a));
        }

        /// <summary>
        /// Swaps the specified a.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        public static void Swap<T>(this IList<T> list, int a, int b)
        {
            T aa = list[a];
            list[a] = list[b];
            list[b] = aa;
        }

        /// <summary>
        /// Manies the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        [Pure]
        [PublicAPI]
        public static bool Many<T>([NotNull] this IEnumerable<T> enumerable, [NotNull] Func<T, bool> predicate)
        {
            return enumerable.Count(predicate) > 1;
        }
        /// <summary>
        /// Empties this instance.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <returns>List&lt;TResult&gt;.</returns>
        [DebuggerStepThrough]
        public static List<TResult> Empty<TResult>()
        {
            return Enumerable.Empty<TResult>().ToList();
        }
        /// <summary>
        /// Ifs the specified condition.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="action">The action.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        [DebuggerStepThrough]
        public static IEnumerable<T> If<T>(this IEnumerable<T> enumerable, bool condition, Func<IEnumerable<T>, IEnumerable<T>> action)
        {
            return condition ? action(enumerable) : enumerable;
        }
        /// <summary>
        /// Fors the each.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="action">The action.</param>
        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
        /// <summary>
        /// Converts to enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        [DebuggerStepThrough]
        public static IEnumerable<T> ToEnumerable<T>(this T source)
        {
            return new[]
            {
                source
            };
        }
        /// <summary>
        /// Throws if any less then equal to zero.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <exception cref="ArgumentException">All file reference ids must be greater then zero.</exception>
        [DebuggerStepThrough]
        public static void ThrowIfAnyLessThenEqualToZero(this IEnumerable<int> source)
        {
            if (source.Any(p => p <= 0))
            {
                throw new ArgumentException("All file reference ids must be greater then zero.", $"{nameof(source)}");
            }
        }
        /// <summary>
        /// Fors the each item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="added">The added.</param>
        /// <param name="removed">The removed.</param>
        /// <param name="reset">The reset.</param>
        /// <returns>IDisposable.</returns>
        [DebuggerStepThrough]
        public static IDisposable ForEachItem<T>(this ObservableCollection<T> collection, Action<T> added, Action<T> removed, Action reset)
        {
            void add(IList items)
            {
                foreach (T item in items)
                {
                    added(item);
                }
            }

            void remove(IList items)
            {
                for (var i = items.Count - 1; i >= 0; --i)
                {
                    removed((T)items[i]);
                }
            }

            void handler(object _, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        add(e.NewItems);
                        break;

                    case NotifyCollectionChangedAction.Move:
                    case NotifyCollectionChangedAction.Replace:
                        remove(e.OldItems);
                        add(e.NewItems);
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        remove(e.OldItems);
                        break;

                    case NotifyCollectionChangedAction.Reset:
                        if (reset == null)
                        {
                            throw new InvalidOperationException(
                                "Reset called on collection without reset handler.");
                        }

                        reset();
                        add(collection);
                        break;
                }
            }

            add(collection);
            collection.CollectionChanged += handler;

            return new ActionDisposable(() => collection.CollectionChanged -= handler);
        }

        /// <summary>
        /// Class ActionDisposable. This class cannot be inherited.
        /// Implements the <see cref="System.IDisposable" />
        /// </summary>
        /// <seealso cref="System.IDisposable" />
        private sealed class ActionDisposable : IDisposable
        {
            /// <summary>
            /// The dispose
            /// </summary>
            private readonly Action dispose;

            /// <summary>
            /// Initializes a new instance of the <see cref="ActionDisposable"/> class.
            /// </summary>
            /// <param name="dispose">The dispose.</param>
            public ActionDisposable(Action dispose)
            {
                this.dispose = dispose;
            }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                dispose();
            }
        }

        /// <summary>
        /// Ignores the nulls.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">The target.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> IgnoreNulls<T>(this IEnumerable<T> target)
        {
            if (ReferenceEquals(target, null))
            {
                yield break;
            }

            foreach (var item in target.Where(item => !ReferenceEquals(item, null)))
            {
                yield return item;
            }
        }

        /// <summary>
        /// Maximums the item.
        /// </summary>
        /// <typeparam name="TItem">The type of the t item.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="maxValue">The maximum value.</param>
        /// <returns>TItem.</returns>
        public static TItem MaxItem<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, TValue> selector, out TValue maxValue)
            where TItem : class
            where TValue : IComparable
        {
            TItem maxItem = null;
            maxValue = default;

            foreach (var item in items)
            {
                if (item == null)
                {
                    continue;
                }

                var itemValue = selector(item);

                if (maxItem != null && itemValue.CompareTo(maxValue) <= 0)
                {
                    continue;
                }

                maxValue = itemValue;
                maxItem = item;
            }

            return maxItem;
        }

        /// <summary>
        /// Maximums the item.
        /// </summary>
        /// <typeparam name="TItem">The type of the t item.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>TItem.</returns>
        public static TItem MaxItem<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, TValue> selector)
            where TItem : class
            where TValue : IComparable
        {
            return items.MaxItem(selector, out _);
        }

        /// <summary>
        /// Minimums the item.
        /// </summary>
        /// <typeparam name="TItem">The type of the t item.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="minValue">The minimum value.</param>
        /// <returns>TItem.</returns>
        public static TItem MinItem<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, TValue> selector, out TValue minValue)
            where TItem : class
            where TValue : IComparable
        {
            TItem minItem = null;
            minValue = default;

            foreach (var item in items)
            {
                if (item == null)
                {
                    continue;
                }

                var itemValue = selector(item);

                if (minItem != null && itemValue.CompareTo(minValue) >= 0)
                {
                    continue;
                }

                minValue = itemValue;
                minItem = item;
            }

            return minItem;
        }

        /// <summary>
        /// Minimums the item.
        /// </summary>
        /// <typeparam name="TItem">The type of the t item.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="items">The items.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>TItem.</returns>
        public static TItem MinItem<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, TValue> selector)
            where TItem : class
            where TValue : IComparable
        {
            return items.MinItem(selector, out _);
        }

        /// <summary>
        /// Distincts the specified expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> expression)
        {
            return source == null ? Enumerable.Empty<T>() : source.GroupBy(expression).Select(i => i.First());
        }

        /// <summary>
        /// Removes the where.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> RemoveWhere<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                yield break;
            }

            foreach (var t in source)
            {
                if (!predicate(t))
                {
                    yield return t;
                }
            }
        }

        /// <summary>
        /// Removes all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        [Obsolete("Use RemoveWhere instead..")]
        public static IEnumerable<T> RemoveAll<T>(this IEnumerable<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                return Enumerable.Empty<T>();
            }

            var list = source.ToList();
            list.RemoveAll(predicate);
            return list;
        }

        /// <summary>
        /// Selects the specified selector.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="allowNull">if set to <c>true</c> [allow null].</param>
        /// <returns>IEnumerable&lt;TResult&gt;.</returns>
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, bool allowNull = true)
        {
            foreach (var item in source)
            {
                var select = selector(item);
                if (allowNull || !Equals(select, default(TSource)))
                {
                    yield return select;
                }
            }
        }

        /// <summary>
        /// Firsts the or default.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>T.</returns>
        public static T FirstOrDefault<T>(this IEnumerable<T> source, T defaultValue)
        {
            return source.IsNotEmpty() ? source.First() : defaultValue;
        }

        /// <summary>
        /// Appends the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="item">The item.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T item)
        {
            foreach (var i in source)
            {
                yield return i;
            }

            yield return item;
        }

        /// <summary>
        /// Prepends the specified item.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="item">The item.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T item)
        {
            yield return item;

            foreach (var i in source)
            {
                yield return i;
            }
        }

        /// <summary>
        /// Converts to array.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>TResult[].</returns>
        public static TResult[] ToArray<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Select(selector).ToArray();
        }

        /// <summary>
        /// Converts to list.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>List&lt;TResult&gt;.</returns>
        public static List<TResult> ToList<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Select(selector).ToList();
        }

        /// <summary>
        /// Sums the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.UInt32.</returns>
        public static uint Sum(this IEnumerable<uint> source)
        {
            return source.Aggregate(0U, (current, number) => current + number);
        }

        /// <summary>
        /// Sums the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.UInt64.</returns>
        public static ulong Sum(this IEnumerable<ulong> source)
        {
            return source.Aggregate(0UL, (current, number) => current + number);
        }

        /// <summary>
        /// Sums the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.Nullable&lt;System.UInt32&gt;.</returns>
        public static uint? Sum(this IEnumerable<uint?> source)
        {
            return source.Where(nullable => nullable.HasValue).Aggregate(0U, (current, nullable) => current + nullable.GetValueOrDefault());
        }

        /// <summary>
        /// Sums the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.Nullable&lt;System.UInt64&gt;.</returns>
        public static ulong? Sum(this IEnumerable<ulong?> source)
        {
            return source.Where(nullable => nullable.HasValue).Aggregate(0UL, (current, nullable) => current + nullable.GetValueOrDefault());
        }

        /// <summary>
        /// Sums the specified selection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selection">The selection.</param>
        /// <returns>System.UInt32.</returns>
        public static uint Sum<T>(this IEnumerable<T> source, Func<T, uint> selection)
        {
            return ElementsNotNullFrom(source).Select(selection).Sum();
        }

        /// <summary>
        /// Elementses the not null from.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        private static IEnumerable<T> ElementsNotNullFrom<T>(IEnumerable<T> source)
        {
            return source.Where(x => x.IsNotNull());
        }

        /// <summary>
        /// Sums the specified selection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selection">The selection.</param>
        /// <returns>System.Nullable&lt;System.UInt32&gt;.</returns>
        public static uint? Sum<T>(this IEnumerable<T> source, Func<T, uint?> selection)
        {
            return ElementsNotNullFrom(source).Select(selection).Sum();
        }

        /// <summary>
        /// Sums the specified selector.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>System.UInt64.</returns>
        public static ulong Sum<T>(this IEnumerable<T> source, Func<T, ulong> selector)
        {
            return ElementsNotNullFrom(source).Select(selector).Sum();
        }

        /// <summary>
        /// Sums the specified selector.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>System.Nullable&lt;System.UInt64&gt;.</returns>
        public static ulong? Sum<T>(this IEnumerable<T> source, Func<T, ulong?> selector)
        {
            return ElementsNotNullFrom(source).Select(selector).Sum();
        }

        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of the t key.</typeparam>
        /// <typeparam name="TValue">The type of the t value.</typeparam>
        /// <param name="groupings">The groupings.</param>
        /// <returns>Dictionary&lt;TKey, List&lt;TValue&gt;&gt;.</returns>
        public static Dictionary<TKey, List<TValue>> ToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> groupings)
        {
            return groupings.ToDictionary(group => group.Key, group => group.ToList());
        }

        /// <summary>
        /// Determines whether [has count of] [the specified count].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="count">The count.</param>
        /// <returns><c>true</c> if [has count of] [the specified count]; otherwise, <c>false</c>.</returns>
        public static bool HasCountOf<T>(this IEnumerable<T> source, int count)
        {
            return source.Take(count + 1).Count() == count;
        }

        /// <summary>
        /// Enums the values to list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_">The .</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        /// <exception cref="ArgumentException">T must be of type System.Enum</exception>
        public static IEnumerable<T> EnumValuesToList<T>(this IEnumerable<T> _)
        {
            var enumType = typeof(T);

            // Can't use generic type constraints on value types,
            // so have to do check like this
            // consider using - enumType.IsEnum()
            if (enumType.BaseType != typeof(Enum))
            {
                throw new ArgumentException("T must be of type System.Enum");
            }

            var enumValArray = Enum.GetValues(enumType);
            var enumValList = new List<T>(enumValArray.Length);
            enumValList.AddRange(from int val in enumValArray select (T)Enum.Parse(enumType, val.ToString()));

            return enumValList;
        }

        /// <summary>
        /// Enums the names to list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public static IEnumerable<string> EnumNamesToList<T>(this IEnumerable<T> collection)
        {
            var cls = typeof(T);

            var enumArrayList = cls.GetInterfaces();

            return (from objType in enumArrayList where objType.IsEnum select objType.Name).ToList();
        }

        /// <summary>
        /// Concats the with.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="formatString">The format string.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="ArgumentNullException">
        /// items
        /// or
        /// separator
        /// </exception>
        public static string ConcatWith<T>(this IEnumerable<T> items, string separator = ",", string formatString = "")
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            if (separator == null)
            {
                throw new ArgumentNullException("separator");
            }

            // shortcut for string enumerable
            if (typeof(T) == typeof(string))
            {
                return string.Join(separator, ((IEnumerable<string>)items).ToArray());
            }

            if (string.IsNullOrEmpty(formatString))
            {
                formatString = "{0}";
            }
            else
            {
                formatString = string.Format("{{0:{0}}}", formatString);
            }

            return string.Join(separator, items.Select(x => string.Format(formatString, x)).ToArray());
        }

        /// <summary>
        /// Merges the distinct inner enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> MergeDistinctInnerEnumerable<T>(this IEnumerable<IEnumerable<T>> @this)
        {
            var listItem = @this.ToList();

            var list = new List<T>();

            foreach (var item in listItem)
            {
                list = list.Union(item).ToList();
            }

            return list;
        }

        /// <summary>
        /// Merges the inner enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> MergeInnerEnumerable<T>(this IEnumerable<IEnumerable<T>> @this)
        {
            var listItem = @this.ToList();

            var list = new List<T>();

            foreach (var item in listItem)
            {
                list.AddRange(item);
            }

            return list;
        }

        /// <summary>
        /// Determines whether the specified values contains all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="values">The values.</param>
        /// <returns><c>true</c> if the specified values contains all; otherwise, <c>false</c>.</returns>
        public static bool ContainsAll<T>(this IEnumerable<T> @this, params T[] values)
        {
            var list = @this.ToArray();
            foreach (var value in values)
            {
                if (!list.Contains(value))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the specified values contains any.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="values">The values.</param>
        /// <returns><c>true</c> if the specified values contains any; otherwise, <c>false</c>.</returns>
        public static bool ContainsAny<T>(this IEnumerable<T> @this, params T[] values)
        {
            var list = @this.ToArray();
            foreach (var value in values)
            {
                if (list.Contains(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Fors the index of the each with.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <param name="action">The action.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> ForEachWithIndex<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            var array = source.ToArray();

            for (var index = 0; index < array.Length; index++)
            {
                action(array[index], index);
            }

            return array;
        }

        /// <summary>
        /// Determines whether the specified this is empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns><c>true</c> if the specified this is empty; otherwise, <c>false</c>.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> @this)
        {
            return !@this.Any();
        }

        /// <summary>
        /// Determines whether [is not empty] [the specified this].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns><c>true</c> if [is not empty] [the specified this]; otherwise, <c>false</c>.</returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> @this)
        {
            return @this.Any();
        }

        /// <summary>
        /// Determines whether [is not null or empty] [the specified this].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns><c>true</c> if [is not null or empty] [the specified this]; otherwise, <c>false</c>.</returns>
        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this != null && @this.Any();
        }

        /// <summary>
        /// Determines whether [is null or empty] [the specified this].
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <returns><c>true</c> if [is null or empty] [the specified this]; otherwise, <c>false</c>.</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> @this)
        {
            return @this == null || !@this.Any();
        }

        /// <summary>
        /// Strings the join.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        public static string StringJoin<T>(this IEnumerable<T> @this, string separator)
        {
            return string.Join(separator, @this);
        }

        /// <summary>
        /// Strings the join.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this">The this.</param>
        /// <param name="separator">The separator.</param>
        /// <returns>System.String.</returns>
        public static string StringJoin<T>(this IEnumerable<T> @this, char separator)
        {
            return string.Join(separator.ToString(), @this);
        }
    }

    /// <summary>
    /// Class StringExtensions.
    /// </summary>
    public static class StringExtensions
    {
    }
}