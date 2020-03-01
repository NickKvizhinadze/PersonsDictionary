using System.Threading.Tasks;
using System.Collections.Generic;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Application.Common;

namespace PersonsDictionary.Application.Persons
{
    public interface IMobileNumbersRepository : IBaseRepository<MobileNumber, int>
    {
        Task<List<MobileNumber>> GetByPersonIdAsync(int personId);
    }
}
