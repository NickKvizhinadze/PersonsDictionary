using PersonsDictionary.Domain.Cities;
using PersonsDictionary.Application.Cities;
using PersonsDictionary.Persistence.Repositories;

namespace PersonsDictionary.Persistence.Cities
{
    public class CitiesRepository : BaseRepository<City, int>, ICitiesRepository
    {
        public CitiesRepository(ApplicationDbContext context) : base(context)
        {
        }        
    }
}
