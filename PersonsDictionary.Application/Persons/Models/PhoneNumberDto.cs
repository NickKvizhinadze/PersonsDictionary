using PersonsDictionary.Domain.Enums;

namespace PersonsDictionary.Application.Persons.Models
{
    public class PhoneNumberDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Value { get; set; }
        public PhoneNumberType Type { get; set; }
    }
}
