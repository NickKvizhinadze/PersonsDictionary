using System.ComponentModel.DataAnnotations;
using PersonsDictionary.Common.Extensions;

namespace PersonsDictionary.Api.Attributes
{
    public class OnlyEnglishOrGeorgianAttribute : ValidationAttribute
    {
        #region Methods
        public override bool IsValid(object value)
        {
            var source = value.ToString();
            return source.IsWithEnglishLetters() || source.IsWithGeorgianLetters();
        }
        #endregion
    }
}
