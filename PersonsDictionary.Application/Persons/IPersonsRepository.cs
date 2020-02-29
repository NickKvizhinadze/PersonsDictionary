using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Application.Common;

namespace PersonsDictionary.Application.Persons
{
    public interface IPersonsRepository: IBaseRepository<Person, int>
    {
        
    }
}
