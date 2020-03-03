using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PersonsDictionary.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            MemberInfo member = value.GetType().GetMember(Enum.GetName(value.GetType(), value))[0];

            var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
            string result;
            if (attrs.Length > 0)
            {
                if (((DisplayAttribute)attrs[0]).ResourceType != null)
                    result = ((DisplayAttribute)attrs[0]).GetName();
                else
                    result = ((DisplayAttribute)attrs[0]).Name;
            }
            else
                result = value.ToString();

            return result;
        }

        public static List<KeyValuePair<int, string>> ToCollection<T>(this Type source) where T : Enum
        {
            return Enum.GetValues(source).Cast<T>()
                .Select(r => 
                    new KeyValuePair<int, string>(Convert.ToInt32(r), r.GetDisplayName())
                    )
                .ToList();
        }
    }
}
