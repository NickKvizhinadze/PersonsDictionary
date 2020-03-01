using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace PersonsDictionary.Api.Attributes
{
    public class MinAgeAttribute : ValidationAttribute
    {
        #region Fields
        public int MinAge { get; private set; }
        #endregion

        #region Constructor
        public MinAgeAttribute(int minAge)
        {
            MinAge = minAge;
        }
        #endregion

        #region Methods
        public override bool IsValid(object value)
        {
            if (value is DateTime)
            {
                var birthdate = (DateTime)value;

                var today = DateTime.Today;
                var age = today.Year - birthdate.Year;
                if (birthdate.Date > today.AddYears(-age)) age--;

                return age >= MinAge;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            Assembly assem = Assembly.Load("PersonsDictionary.Localization");
            ResourceManager rman = new ResourceManager("PersonsDictionary.Localization." + ErrorMessageResourceType.Name, assem);
            var s = rman.GetString(ErrorMessageResourceName);
            return string.Format(s, MinAge);
        }
        #endregion
    }
}
