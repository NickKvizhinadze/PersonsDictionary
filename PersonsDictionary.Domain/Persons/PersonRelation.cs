using PersonsDictionary.Domain.Common;
using PersonsDictionary.Domain.Enums;

namespace PersonsDictionary.Domain.Persons
{
    public class PersonRelation: Entity
    {
        #region Constructor 
        private PersonRelation()
        {
        }

        public PersonRelation(PersonRelationType type, Person person, Person relatedPerson)
        {
            Type = type;
            Person = person;
            RelatedPerson = relatedPerson;
        }
        #endregion

        #region Navigation Properties
        public PersonRelationType Type { get; private set; }
        #endregion

        #region Navigation Properties
        public Person Person { get; private set; }
        public Person RelatedPerson { get; private set; }
        #endregion
    }
}
