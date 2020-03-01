using PersonsDictionary.Domain.Enums;

namespace PersonsDictionary.Application.Persons.Models
{
    public class RelatedPersonCreateRequest
    {
        public int RelatedPersonId { get; set; }
        public PersonRelationType Type { get; set; }
    }
}
