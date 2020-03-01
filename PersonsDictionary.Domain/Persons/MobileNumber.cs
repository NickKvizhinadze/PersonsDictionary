using PersonsDictionary.Domain.Common;

namespace PersonsDictionary.Domain.Persons
{
    public class MobileNumber : Entity
    {
        #region Properties
        public int PersonId { get; set; }
        public string Value { get; set; }
        #endregion

        #region Navigation Properties
        public Person Person { get; set; }
        #endregion
    }
}
