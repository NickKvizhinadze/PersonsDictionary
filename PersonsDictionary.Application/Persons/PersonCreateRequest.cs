using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using PersonsDictionary.Domain.Enums;
using PersonsDictionary.Localization;

namespace PersonsDictionary.Application.Persons
{
    public class PersonCreateRequest
    {
        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.MinAndMaxLength))]
        //TODO: chack language
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.MinAndMaxLength))]
        //TODO: chack language
        public string LastName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        [StringLength(11, MinimumLength = 11, ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.StringLength))]
        public string PersonalId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        public Gender Gender { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        //TODO: min age validator
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorMessages), ErrorMessageResourceName = nameof(ErrorMessages.Required))]
        public int CityId { get; set; }
        
        public IFormFile Image { get; set; }
    }
}
