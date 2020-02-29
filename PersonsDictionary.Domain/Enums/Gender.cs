using PersonsDictionary.Localization;
using System.ComponentModel.DataAnnotations;

namespace PersonsDictionary.Domain.Enums
{
    public enum Gender
    {
        [Display(ResourceType = typeof(Models), Name = nameof(Models.Male))]
        Male,
        [Display(ResourceType = typeof(Models), Name = nameof(Models.Female))]
        Female
    }
}
