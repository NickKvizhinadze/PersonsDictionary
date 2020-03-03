using System.Text.RegularExpressions;

namespace PersonsDictionary.Common.Extensions
{
    public static class StringExtentions
    {
        public static bool IsWithEnglishLetters(this string value)
        {
            Regex regexObj = new Regex("^[A-Za-z]+$");
            return regexObj.IsMatch(value);
        }

        public static bool IsWithGeorgianLetters(this string value)
        {
            Regex regexObj = new Regex("^[ა-ჰ]+$");
            return regexObj.IsMatch(value);
        }
    }
}
