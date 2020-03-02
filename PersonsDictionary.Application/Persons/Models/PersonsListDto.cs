using System.Collections.Generic;
using PersonsDictionary.Common.Models;

namespace PersonsDictionary.Application.Persons.Models
{
    public class PersonsListDto
    {
        public PersonsListDto(List<PersonDto> persons, Paging paging)
        {
            Persons = persons;
            Paging = paging;
        }

        public List<PersonDto> Persons { get; private set; }

        public Paging Paging { get; private set; }
    }
}
