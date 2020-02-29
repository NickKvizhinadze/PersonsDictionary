using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Application.Persons;
using PersonsDictionary.Persistence.Repositories;

namespace PersonsDictionary.Persistence.Persons
{
    public class PersonsRepository : BaseRepository<Person, int>, IPersonsRepository
    {
        public PersonsRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
