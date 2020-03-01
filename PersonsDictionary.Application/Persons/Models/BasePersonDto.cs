using System;
using PersonsDictionary.Domain.Enums;

namespace PersonsDictionary.Application.Persons.Models
{
    public class BasePersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string ImageUrl { get; set; }
    }
}
