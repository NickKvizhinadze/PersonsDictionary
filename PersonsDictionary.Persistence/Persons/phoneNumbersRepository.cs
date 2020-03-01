using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Application.Persons;
using PersonsDictionary.Persistence.Repositories;

namespace PersonsDictionary.Persistence.Persons
{
    public class PhoneNumbersRepository : BaseRepository<PhoneNumber, int>, IPhoneNumbersRepository
    {
        #region Constructor
        public PhoneNumbersRepository(ApplicationDbContext context) : base(context)
        {
        }
        #endregion

        #region Methods
        public Task<List<PhoneNumber>> GetByPersonIdAsync(int personId)
        {
            return TableNoTracking.Where(n => n.PersonId == personId).ToListAsync();
        }
        #endregion
    }
}
