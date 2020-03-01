using System;
using System.Collections.Generic;
using PersonsDictionary.Domain.Enums;
using PersonsDictionary.Domain.Common;
using PersonsDictionary.Domain.Cities;

namespace PersonsDictionary.Domain.Persons
{
    public class Person : Entity
    {
        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalId { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public string ImageUrl { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public ICollection<PersonRelation> Relations { get; set; }
        public ICollection<PersonRelation> RelatedToRelations { get; set; }
        public City City { get; set; }
        #endregion
    }
}
