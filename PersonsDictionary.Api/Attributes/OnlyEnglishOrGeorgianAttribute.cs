using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PersonsDictionary.Api.Attributes
{
    public class OnlyEnglishOrGeorgianAttribute : ValidationAttribute
    {
        #region Methods
        public override bool IsValid(object value)
        {
            var source = value.ToString();
            return IsWithEnglishLetters(source) || IsWithGeorgianLetters(source);
        }
        #endregion

        #region Private Methods
        private bool IsWithEnglishLetters(string value)
        {
            Regex regexObj = new Regex("^[A-Za-z]+$");
            return regexObj.IsMatch(value);
        }
        private bool IsWithGeorgianLetters(string value)
        {
            Regex regexObj = new Regex("^[ა-ჰ]+$");
            return regexObj.IsMatch(value);
        }
        #endregion
    }
}
