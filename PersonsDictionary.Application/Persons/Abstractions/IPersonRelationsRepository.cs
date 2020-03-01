using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Application.Common;

namespace PersonsDictionary.Application.Persons.Abstractions
{
    public interface IPersonRelationsRepository : IBaseRepository<PersonRelation, int>
    {
    }
}
