using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Ensure;

namespace TheFund.AtidsXe.Modules.Common.Extensions
{
    public static class EnsureExtensions
    {
        [DebuggerStepThrough]
        public static void EnsureGreaterThenZero(this int id, string message = null)
        {
            id.Ensure
            (
                p => p > 0, 
                string.IsNullOrWhiteSpace(message) ? $"{nameof(id)} must be greater then zero" : message
            );
        }

        [DebuggerStepThrough]
        public static void EnsureGreaterThenZero(this IEnumerable<int> ids, string message = null)
        {
            ids.Ensure
            (
                p => p.All(id => id > 0),
                string.IsNullOrWhiteSpace(message) ? "All identifiers must be greater then zero" : message
            );
        }
    }
}