using DynamicFilter.Attributes;
using DynamicFilter.Enums;
using DynamicFilter.Models;
using PersonsDictionary.Domain.Enums;
using PersonsDictionary.Domain.Persons;

namespace PersonsDictionary.Application.Persons.Models
{
    [FilterFor(typeof(Person))]
    public class PersonFilter: BaseFilter
    {
        [FilterMethod(FilterMethods.StringContains, nameof(Person.FirstName))]
        public string FirstName { get; set; }

        [FilterMethod(FilterMethods.StringContains, nameof(Person.LastName))]
        public string LastName { get; set; }

        [FilterMethod(FilterMethods.StringContains, nameof(Person.PersonalId))]
        public string PersonalId { get; set; }

        [FilterMethod(FilterMethods.Equal, nameof(Person.Gender))]
        public Gender? Gender { get; set; }

        [FilterMethod(FilterMethods.Equal, nameof(Person.CityId))]
        public int? CityId { get; set; }
    }
}
