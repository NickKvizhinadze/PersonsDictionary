using PersonsDictionary.Domain.Common;
using PersonsDictionary.Domain.Persons;
using System.Collections.Generic;

namespace PersonsDictionary.Domain.Cities
{
    public class City: Entity
    {
        #region Properties
        public string Name { get; set; }
        #endregion

        #region Navigation Properties
        public ICollection<Person> Persons{ get; set; }
        #endregion
    }
}
