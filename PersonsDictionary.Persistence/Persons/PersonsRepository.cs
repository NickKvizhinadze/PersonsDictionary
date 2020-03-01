﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        #region Methods
        public Task<string> GetImageUrlAsync(int id) 
            => TableNoTracking.Where(p => p.Id == id).Select(p => p.ImageUrl).FirstOrDefaultAsync();
        #endregion
    }
}
