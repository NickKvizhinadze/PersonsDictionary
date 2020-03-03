using PersonsDictionary.Application.Persons.Abstractions;

namespace PersonsDictionary.Application.Collections.Abstractions
{
    public interface ICollectionsUow: IBaeUow
    {
        IPersonsRepository Persons { get; }
    }
}
