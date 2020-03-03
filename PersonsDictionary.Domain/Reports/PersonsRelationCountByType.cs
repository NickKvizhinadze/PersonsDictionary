using PersonsDictionary.Domain.Enums;

namespace PersonsDictionary.Domain.Reports
{
    public class PersonsRelationCountByType
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public PersonRelationType Type { get; set; }
        public int Count { get; set; }
    }
}
