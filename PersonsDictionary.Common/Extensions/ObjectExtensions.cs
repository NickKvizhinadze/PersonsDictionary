using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsDictionary.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static void ThrowIfArgumentNull<T>(this T obj, string parameterName) where T : class
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
        public static void ThrowIfArgumentNull<T>(this T? obj, string parameterName) where T : struct
        {
            if (!obj.HasValue)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

    }
}
