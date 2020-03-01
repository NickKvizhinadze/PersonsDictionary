using PersonsDictionary.Localization;
using System.ComponentModel.DataAnnotations;

namespace PersonsDictionary.Domain.Enums
{
    public enum PersonRelationType
    {
        [Display(ResourceType = typeof(Models), Name = nameof(Models.Colleague))]
        Colleague,
        [Display(ResourceType = typeof(Models), Name = nameof(Models.Acquaintance))]
        Acquaintance,
        [Display(ResourceType = typeof(Models), Name = nameof(Models.Relative))]
        Relative,
        [Display(ResourceType = typeof(Models), Name = nameof(Models.Other))]
        Other
    }
}
