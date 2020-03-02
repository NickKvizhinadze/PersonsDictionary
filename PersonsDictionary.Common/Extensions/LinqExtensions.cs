using System;

namespace PersonsDictionary.Common.Extensions
{
    public static class LinqExtensions
    {
        public static bool CotnainsIgnoreCase(this string source, string value) 
            => source.ToLower().Contains(value.ToLower());
    }
}
