using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using PersonsDictionary.Domain.Enums;

namespace PersonsDictionary.Application.Persons
{
    public class PersonCreateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }

        public List<PhoneNumberDto> PhoneNumbers { get; set; }
    }
}
