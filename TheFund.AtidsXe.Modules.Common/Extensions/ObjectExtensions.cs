using System;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace TheFund.AtidsXe.Modules.Common.Extensions
{
    public static class ObjectExtensions
    {
        [DebuggerStepThrough]
        public static bool IsNotNull<T>(this T source)
        {
            return null != source;
        }
        [DebuggerStepThrough]
        public static bool IsNull<T>(this T source)
        {
            if (source is INullable && (source as INullable).IsNull)
            {
                return true;
            }

            var type = typeof(T);

            if (type.IsValueType)
            {
                if (!(Nullable.GetUnderlyingType(type) is null) && source.GetHashCode() == 0)
                {
                    return true;
                }
            }
            else
            {
                if (source == null)
                {
                    return true;
                }

                if (Convert.IsDBNull(source))
                {
                    return true;
                }
            }

            return false;
        }
        [DebuggerStepThrough]
        public static bool IsNull<T>(this T? source) where T : struct
        {
            return !source.HasValue;
        }
        [DebuggerStepThrough]
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
