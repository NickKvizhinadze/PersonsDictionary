using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Application.Persons;
using PersonsDictionary.Persistence.Repositories;

namespace PersonsDictionary.Persistence.Persons
{
    public class MobileNumbersRepository : BaseRepository<MobileNumber, int>, IMobileNumbersRepository
    {
        #region Constructor
        public MobileNumbersRepository(ApplicationDbContext context) : base(context)
        {
        }
        #endregion

        #region Methods
        public Task<List<MobileNumber>> GetByPersonIdAsync(int personId)
        {
            return TableNoTracking.Where(n => n.PersonId == personId).ToListAsync();
        }
        #endregion
    }
}
