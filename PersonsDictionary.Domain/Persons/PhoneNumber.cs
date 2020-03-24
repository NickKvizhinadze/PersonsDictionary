using PersonsDictionary.Domain.Enums;
using PersonsDictionary.Domain.Common;

namespace PersonsDictionary.Domain.Persons
{
    public class PhoneNumber : Entity
    {
        #region Constructor
        public PhoneNumber(int id, PhoneNumberType type, string value)
            :base(id)
        {
            Update(type, value);
        }
        #endregion

        #region Properties
        public int PersonId { get; private set; }
        public string Value { get; private set; }
        public PhoneNumberType Type { get; private set; }
        #endregion

        #region Navigation Properties
        public Person Person { get; set; }
        #endregion

        #region Methods
        public void Update(PhoneNumberType type, string value)
        {
            Type = type;
            Value = value;
        }
        #endregion
    }
}
