using PersonsDictionary.Localization;
using System.ComponentModel.DataAnnotations;

namespace PersonsDictionary.Domain.Enums
{
    public enum PhoneNumberType
    {
        [Display(ResourceType = typeof(Models), Name = nameof(Models.Mobile))]
        Mobile,
        [Display(ResourceType = typeof(Models), Name = nameof(Models.Office))]
        Office,
        [Display(ResourceType = typeof(Models), Name = nameof(Models.Home))]
        Home
    }
}
