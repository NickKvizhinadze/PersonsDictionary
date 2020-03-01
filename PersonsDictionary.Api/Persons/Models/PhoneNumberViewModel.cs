using System.ComponentModel.DataAnnotations;
using PersonsDictionary.Domain.Enums;
using PersonsDictionary.Localization;

namespace PersonsDictionary.Api.Persons.Models
{
    public class PhoneNumberViewModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        public string Value { get; set; }
        public PhoneNumberType Type { get; set; }
    }
}
