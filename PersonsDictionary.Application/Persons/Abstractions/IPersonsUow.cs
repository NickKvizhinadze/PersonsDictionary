using PersonsDictionary.Application.Cities;
using PersonsDictionary.Application.Common;

namespace PersonsDictionary.Application.Persons.Abstractions
{
    public interface IPersonsUow : IBaseUow
    {
        IPersonsRepository Persons { get; }
        IPersonRelationsRepository PersonRelations { get; }
        IPhoneNumbersRepository PhoneNumbers { get; }
        ICitiesRepository Cities { get; }
    }
}
