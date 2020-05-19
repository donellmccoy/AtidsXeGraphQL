using System.Threading;
using System.Threading.Tasks;

namespace TheFund.AtidsXe.Modules.Common.Constants
{
    /// <summary>
    /// Provides completed task constants.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    public static class TaskConstants<T>
    {
        private static readonly Task<T> defaultValue = Task.FromResult(default(T));
        private static readonly Task<T> canceled = Task.FromCanceled<T>(new CancellationToken(true));

        /// <summary>
        /// A task that has been completed with the default value of <typeparamref name="T"/>.
        /// </summary>
        public static Task<T> Default => defaultValue;

        /// <summary>
        /// A task that has been canceled.
        /// </summary>
        public static Task<T> Canceled => canceled;
    }

    public static class TaskConstants
    {
        private static readonly Task<bool> booleanTrue = Task.FromResult(true);
        private static readonly Task<int> intNegativeOne = Task.FromResult(-1);

        /// <summary>
        /// A task that has been completed with the value <c>true</c>.
        /// </summary>
        public static Task<bool> BooleanTrue => booleanTrue;

        /// <summary>
        /// A task that has been completed with the value <c>false</c>.
        /// </summary>
        public static Task<bool> BooleanFalse => TaskConstants<bool>.Default;

        /// <summary>
        /// A task that has been completed with the value <c>0</c>.
        /// </summary>
        public static Task<int> Int32Zero => TaskConstants<int>.Default;

        /// <summary>
        /// A task that has been completed with the value <c>-1</c>.
        /// </summary>
        public static Task<int> Int32NegativeOne => intNegativeOne;

        /// <summary>
        /// A <see cref="Task"/> that has been completed.
        /// </summary>
        public static Task Completed => Task.CompletedTask;

        /// <summary>
        /// A task that has been canceled.
        /// </summary>
        public static Task Canceled => TaskConstants<object>.Canceled;
    }
}