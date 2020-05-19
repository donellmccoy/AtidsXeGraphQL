using Ensure;
using System;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.Modules.Common.Extensions
{
    public static class TaskExtensions
    {
        public static async Task Catch(this Task task, Action<Exception> handler = null)
        {
            task.EnsureNotNull(nameof(task));

            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler?.Invoke(ex);
            }
        }

        public static async void SafeFireAndForget(this Task task, bool continueOnCapturedContext = true, Action<Exception> onException = null)
        {
            task.EnsureNotNull(nameof(task));

            try
            {
                await task.ConfigureAwait(continueOnCapturedContext);
            }
            catch (Exception ex) when(onException != null)
            {
                onException(ex);
            }
        }
    }
}