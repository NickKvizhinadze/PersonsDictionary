using System.Threading.Tasks;
using System.Collections.Generic;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Application.Common;

namespace PersonsDictionary.Application.Persons
{
    public interface IPhoneNumbersRepository : IBaseRepository<PhoneNumber, int>
    {
        Task<List<PhoneNumber>> GetByPersonIdAsync(int personId);
    }
}
