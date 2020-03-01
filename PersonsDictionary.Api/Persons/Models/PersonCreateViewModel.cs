using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PersonsDictionary.Api.Attributes;
using PersonsDictionary.Domain.Enums;
using PersonsDictionary.Localization;

namespace PersonsDictionary.Api.Persons.Models
{
    public class PersonCreateViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.MinAndMaxLength))]
        [OnlyEnglishOrGeorgian(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.OnlyEnglishOrGeorgian))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.MinAndMaxLength))]
        [OnlyEnglishOrGeorgian(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.OnlyEnglishOrGeorgian))]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        [StringLength(11, MinimumLength = 11, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.StringLength))]
        public string PersonalId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        public Gender Gender { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        [MinAge(18, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.MinAge))]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        public int CityId { get; set; }

        public List<PhoneNumberViewModel> PhoneNumbers { get; set; }
    }
}
