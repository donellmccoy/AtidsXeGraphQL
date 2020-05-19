using JetBrains.Annotations;
using ReactiveUI;
using System;
using System.ComponentModel.Composition;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using TheFund.AtidsXe.Modules.Common.Factories;

namespace TheFund.AtidsXe.Modules.Common.Models
{
    [Export(typeof(IStatusBarMessageQueue))]
	[PartCreationPolicy(CreationPolicy.Shared)]
    public class StatusBarMessageQueue : IStatusBarMessageQueue
    {
        private readonly Subject<IStatusBarMessage> _subject = new Subject<IStatusBarMessage>();
        private readonly IConnectableObservable<IStatusBarMessage> _connectableObservable;

        public StatusBarMessageQueue()
        {
            _connectableObservable = _subject.SubscribeOn(RxApp.TaskpoolScheduler).Publish();
            _connectableObservable.Connect();
        }

        public void QueueMessage([NotNull] IStatusBarMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            _subject.OnNext(message);
        }

        public void QueueMessage(string message = null)
        {
            _subject.OnNext(StatusBarMessageFactory.Create(message));
        }

        public void RegisterHandler<T>([NotNull] Action<T> action) where T : IStatusBarMessage
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            _connectableObservable.OfType<T>()
								  .ObserveOn(RxApp.MainThreadScheduler)
                                  .Subscribe(action);
        }
    }
}
