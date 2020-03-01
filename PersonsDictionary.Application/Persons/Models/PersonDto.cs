using System.Collections.Generic;

namespace PersonsDictionary.Application.Persons.Models
{

    public class PersonDto : BasePersonDto
    {
        public List<PhoneNumberDto> PhoneNumbers { get; set; }
        public List<RelatedPersonDto> RelatedPersons { get; set; }
    }
}
