using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Persistence.Repositories;
using PersonsDictionary.Application.Persons.Abstractions;

namespace PersonsDictionary.Persistence.Persons
{
    public class PersonRelationsRepository : BaseRepository<PersonRelation, int>, IPersonRelationsRepository
    {
        public PersonRelationsRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
