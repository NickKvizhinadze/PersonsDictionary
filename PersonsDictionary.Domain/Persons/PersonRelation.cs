using PersonsDictionary.Domain.Common;
using PersonsDictionary.Domain.Enums;

namespace PersonsDictionary.Domain.Persons
{
    public class PersonRelation: Entity
    {
        #region Navigation Properties
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public PersonRelationType Type { get; set; }
        #endregion

        #region Navigation Properties
        public Person Person { get; set; }
        public Person RelatedPerson { get; set; }
        #endregion
    }
}
