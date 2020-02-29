using System;
using PersonsDictionary.Domain.Enums;
using PersonsDictionary.Domain.Common;

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
    }
}
