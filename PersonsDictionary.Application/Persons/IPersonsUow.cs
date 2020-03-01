using PersonsDictionary.Application.Cities;
using PersonsDictionary.Application.Common;

namespace PersonsDictionary.Application.Persons
{
    public interface IPersonsUow : IBaseUow
    {
        IPersonsRepository Persons { get; }
        IMobileNumbersRepository MobileNumbers { get; }
        ICitiesRepository Cities { get; }
    }
}
