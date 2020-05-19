using System;

namespace TheFund.AtidsXe.Modules.Services.StatusBarService
{
	public interface IStatusBarService
	{
		IObservable<string> UpdateStatus(IObservable<string> observable);
	}
}