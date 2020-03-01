using System.ComponentModel.DataAnnotations;
using PersonsDictionary.Localization;

namespace PersonsDictionary.Api.Persons.Models
{
    public class MobileNumberViewModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        public string Value { get; set; }
    }
}
