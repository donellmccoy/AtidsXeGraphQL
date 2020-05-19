using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;

namespace TheFund.AtidsXe.Modules.Services.StatusBarService
{
	public class StatusBarService : IStatusBarService
	{
		public IObservable<string> UpdateStatus(IObservable<string> observable)
		{
			return Observable.Create<string>(observer =>
			{
				observable.Subscribe(message => observer.OnNext(message),
									 ex => observer.OnError(ex),
									 () => observer.OnCompleted());

				return Disposable.Empty;
			});
		}
    }
}
