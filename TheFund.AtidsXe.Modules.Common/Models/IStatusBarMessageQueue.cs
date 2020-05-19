using System;

namespace TheFund.AtidsXe.Modules.Common.Models 
{
	public interface IStatusBarMessageQueue
	{
		void QueueMessage(IStatusBarMessage message);
		void RegisterHandler<T>(Action<T> action) where T : IStatusBarMessage;
        void QueueMessage(string message);
	}
}