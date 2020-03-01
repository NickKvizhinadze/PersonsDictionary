using PersonsDictionary.Domain.Enums;
using PersonsDictionary.Domain.Common;

namespace PersonsDictionary.Domain.Persons
{
    public class PhoneNumber : Entity
    {
        #region Properties
        public int PersonId { get; set; }
        public string Value { get; set; }
        public PhoneNumberType Type { get; set; }
        #endregion

        #region Navigation Properties
        public Person Person { get; set; }
        #endregion
    }
}
