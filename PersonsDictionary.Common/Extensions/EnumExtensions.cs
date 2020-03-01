using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

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
    }
}
