using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using TheFund.AtidsXe.Modules.Common.Constants;
using TheFund.AtidsXe.Modules.Common.DataTransferObjects;

namespace TheFund.AtidsXe.Modules.Common.Extensions
{
    public static class ObservableExtensions
    {
        /// <summary>
        /// Returns an observable sequence that terminates with an exception if the source observable
        /// doesn't produce any values. If the source observable produces values or errors those are
        /// forwarded transparently.
        /// </summary>
        /// <param name="observable">The source observable.</param>
        /// <param name="exception">The exception to use if the source observable doesn't produce a value.</param>
        public static IObservable<T> ErrorIfEmpty<T>(this IObservable<T> observable, Exception exception)
        {
            return observable
                .Materialize()
                .Scan(Tuple.Create<bool, Notification<T>>(false, null),
                    (prev, cur) => Tuple.Create(prev.Item1 || cur.Kind == NotificationKind.OnNext, cur))
                .SelectMany(x => !x.Item1 && x.Item2.Kind == NotificationKind.OnCompleted
                    ? Observable.Throw<Notification<T>>(exception)
                    : Observable.Return(x.Item2))
                .Dematerialize();
        }

        /// <summary>
        /// Helper method to transform an IObservable{T} to IObservable{Unit}.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="observable"></param>
        /// <returns></returns>
        public static IObservable<Unit> SelectUnit<T>(this IObservable<T> observable)
        {
            return observable.Select<T, Unit>(_ => Unit.Default);
        }

        /// <summary>
        /// Subscribes to and produces values from the observable returned 
        /// by <paramref name="selector"/> once the source <paramref name="observable"/> 
        /// has completed while ignoring all elements produced from the source.
        /// </summary>
        /// <typeparam name="T">The type of the source observable</typeparam>
        /// <typeparam name="TRet">The type of the resulting observable.</typeparam>
        /// <param name="observable">The source observable.</param>
        /// <param name="selector">The selector for producing the return observable.</param>
        public static IObservable<TRet> ContinueAfter<T, TRet>(this IObservable<T> observable, Func<IObservable<TRet>> selector)
        {
            return observable.AsCompletion().SelectMany(_ => selector());
        }

        public static IObservable<string> WithCache(this IObservable<string> observable, 
            Func<string, string> get,
            Func<string, Task<string>> put)
        {
            return Observable.Create<string>(observer =>
            {
                observable.Subscribe(async term =>
                {
                    var json = get(term);
                    if (json == null)
                    {
                        json = await put(term);
                    }
                    observer.OnNext(json);
                },
                ex => observer.OnError(ex),
                () => observer.OnCompleted());

                return Disposable.Empty;
            });
        }

        public static IObservable<string> WithCache(
            this IObservable<string> observable,
            Func<string, string> get,
            Func<string, Task<string>> retrieve,
            Action<string, string> put)
        {
            return Observable.Create<string>(observer =>
            {
                observable.Subscribe(async term =>
                {
                    var json = get(term);
                    if (json == null)
                    {
                        json = await retrieve(term);
                        put(term, json);
                    }
                    observer.OnNext(json);
                },
                ex => observer.OnError(ex),
                () => observer.OnCompleted());

                return Disposable.Empty;
            });
        }

        public static IObservable<TResult> WithCache<TSource, TResult>(
            this IObservable<TSource> observable, 
            Func<TSource, Func<Task<TResult>>> selector)
        {
            return Observable.Create<TResult>(observer =>
            {
                observable.Subscribe(async term =>
                {
                    observer.OnNext(await selector(term)());
                },
                ex => observer.OnError(ex),
                () => observer.OnCompleted());

                return Disposable.Empty;
            });
        }

        /// <summary>
        /// Flattens an observable of enumerables into a stream of individual signals.
        /// </summary>
        /// <remarks>
        /// I end up doing this a lot and it looks cleaner. Note that this could produce bad results if you expect
        /// the observable to return a single collection and it returns multiple collections.
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="observable"></param>
        /// <returns></returns>
        public static IObservable<T> Flatten<T>(this IObservable<IEnumerable<T>> observable)
        {
            return observable.SelectMany(items => items);
        }

        /// <summary>
        /// Used in cases where we only care when an observable completes and not what the observed values are.
        /// This is commonly used by some of our "Refresh" methods.
        /// </summary>
        public static IObservable<Unit> AsCompletion<T>(this IObservable<T> observable)
        {
            return observable
                .SelectMany(_ => Observable.Empty<Unit>())
                .Concat(Observable.Return(Unit.Default));
        }

        public static IObservable<T> WhereNotNull<T>(this IObservable<T> observable) where T : class
        {
            return observable.Where(item => item != null);
        }

        public static IObservable<T> PublishAsync<T>(this IObservable<T> observable)
        {
            var ret = observable.Multicast(new AsyncSubject<T>());
            ret.Connect();

            return ret;
        }

        public static IObservable<T> LazilyConnect<T>(this IConnectableObservable<T> connectable, SingleAssignmentDisposable futureDisposable)
        {
            var connected = 0;

            return Observable.Create<T>(observer =>
            {
                var subscription = connectable.Subscribe(observer);

                if (Interlocked.CompareExchange(ref connected, 1, 0) == 0)
                {
                    if (!futureDisposable.IsDisposed)
                    {
                        futureDisposable.Disposable = connectable.Connect();
                    }
                }

                return subscription;

            }).AsObservable();
        }

        public static IObservable<T> CacheFirstResult<T>(this IObservable<T> observable)
        {
            return observable.Take(1).PublishLast().LazilyConnect(new SingleAssignmentDisposable());
        }

        public static IObservable<T> TakeUntilInclusive<T>(this IObservable<T> observable, Func<T, bool> predicate)
        {
            return Observable.Create<T>(
                observer => observable.Subscribe(
                    item =>
                    {
                        observer.OnNext(item);
                        if (predicate(item))
                        {
                            observer.OnCompleted();
                        }
                    },
                    observer.OnError,
                    observer.OnCompleted
                )
            );
        }

        public static IObservable<T> OnSubscribe<T>(this IObservable<T> observable, Action action)
        {
            return Observable.Create<T>(observer =>
            {
                action();
                return observable.Subscribe(observer);
            });
        }

        public static IObservable<T> OnSubscribe<T>(this IObservable<T> observable, Func<Task> action)
        {
            return Observable.Create<T>(observer =>
            {
                observable.Subscribe(async item =>
                {
                    if(item != null)
                    {
                        await action();
                    }
                    observer.OnNext(item);
                },
                ex => observer.OnError(ex),
                () => observer.OnCompleted());

                return Disposable.Empty;
            });
        }

        public static IObservable<T> OnSubscribe<T>(this IObservable<T> observable, Action<T> action)
        {
            return Observable.Create<T>(observer =>
            {
                return observable.Subscribe(item =>
                {
                    if (item != null)
                    {
                        action(item);
                    }
                    observer.OnNext(item);
                },
                ex => observer.OnError(ex),
                () => observer.OnCompleted());
            });
        }

        //public static IObservable<TResult> SelectOrDefault<TSource, TResult>(
        //    this IObservable<TSource> observable, 
        //    Func<TSource, TResult> selector,
        //    Func<TSource, bool> condition, 

        //    TResult defaultValue)
        //{
        //    //public static IObservable<TResult> FromAsync<TResult>(Func<CancellationToken, Task<TResult>> functionAsync);
        //    //Observable.FromAsync(token => GetFileReferencesByNameAsync(term, _cancellationTokenSource.Token))
        //    //public static IObservable<TResult> Select<TSource, TResult>(this IObservable<TSource> source, Func<TSource, TResult> selector);

        //    if (condition())
        //    {
        //        return Observable.Return(defaultValue);
        //    }

        //    return observable.Select(selector);
        //}

        public static IObservable<T> ObserveLatestOn<T>(this IObservable<T> observable, IScheduler scheduler)
        {
            return Observable.Create<T>(observer =>
            {
                var gate = new object();
                bool active = false;
                var cancelable = new SerialDisposable();
                var disposable = observable.Materialize().Subscribe(thisNotification =>
                {
                    bool wasNotAlreadyActive;
                    Notification<T> outsideNotification;
                    lock (gate)
                    {
                        wasNotAlreadyActive = !active;
                        active = true;
                        outsideNotification = thisNotification;
                    }

                    if (wasNotAlreadyActive)
                    {
                        cancelable.Disposable = scheduler.Schedule(self =>
                        {
                            Notification<T> localNotification;
                            lock (gate)
                            {
                                localNotification = outsideNotification;
                                outsideNotification = null;
                            }
                            localNotification.Accept(observer);
                            bool hasPendingNotification;
                            lock (gate)
                            {
                                hasPendingNotification = active = (outsideNotification != null);
                            }
                            if (hasPendingNotification)
                            {
                                self();
                            }
                        });
                    }
                });
                return new CompositeDisposable(disposable, cancelable);
            });
        }
    }
}