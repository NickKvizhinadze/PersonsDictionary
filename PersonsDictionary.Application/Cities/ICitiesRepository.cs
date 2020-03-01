using PersonsDictionary.Domain.Cities;
using PersonsDictionary.Application.Common;

namespace PersonsDictionary.Application.Cities
{
    public interface ICitiesRepository: IBaseRepository<City, int>
    {        
    }
}
