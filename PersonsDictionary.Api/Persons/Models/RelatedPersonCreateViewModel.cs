using PersonsDictionary.Domain.Enums;

namespace PersonsDictionary.Api.Persons.Models
{
    public class RelatedPersonCreateViewModel
    {
        public int RelatedPersonId { get; set; }
        public PersonRelationType Type { get; set; }
    }
}
