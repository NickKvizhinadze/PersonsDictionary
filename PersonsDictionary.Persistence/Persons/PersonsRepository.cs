using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PersonsDictionary.Common.Models;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Common.Extensions;
using PersonsDictionary.Persistence.Repositories;
using PersonsDictionary.Application.Persons.Abstractions;
using PersonsDictionary.Application.Persons.Models;
using DynamicFilter.Helpers;

namespace PersonsDictionary.Persistence.Persons
{
    public class PersonsRepository : BaseRepository<Person, int>, IPersonsRepository
    {
        #region Constructor
        public PersonsRepository(ApplicationDbContext context) : base(context)
        {
        }
        #endregion

        #region Methods
        public async Task<(List<Person> persons, int totalCount)> GetAllAsync(string searchValue, Paging paging)
        {
            var query = GetWithIncludes().Where(p =>
                p.FirstName.ToLower().Contains(searchValue.ToLower()) ||
                p.LastName.ToLower().Contains(searchValue.ToLower()) ||
                p.PersonalId.Contains(searchValue)
            );

            var totalCount = await query.CountAsync();


            var result = await query
                       .Skip((paging.CurrentPage - 1) * paging.PerPage)
                       .Take(paging.PerPage)
                       .ToListAsync();

            return (result, totalCount);
        }

        public async Task<(List<Person> persons, int totalCount)> GetAllAsync(PersonFilter filter, Paging paging)
        {
            var query = GetWithIncludes();
            //Filter persons query
            query = FilterHelper.Filter(filter, query);

            var totalCount = await query.CountAsync();

            var result = await query
                       .Skip((paging.CurrentPage - 1) * paging.PerPage)
                       .Take(paging.PerPage)
                       .ToListAsync();

            return (result, totalCount);
        }

        public Task<Person> GetByIdWithTrackingAsync(int id)
            => GetWithIncludes(true).FirstOrDefaultAsync(p => p.Id == id);

        public override Task<Person> GetByIdAsync(int id)
            => GetWithIncludes().FirstOrDefaultAsync(p => p.Id == id);

        public Task<string> GetImageUrlAsync(int id)
            => TableNoTracking.Where(p => p.Id == id).Select(p => p.ImageUrl).FirstOrDefaultAsync();

        public Task<List<KeyValuePair<int, string>>> GetPersonsCollectionAsync()
            => TableNoTracking.Select(p => new KeyValuePair<int, string>(p.Id, $"{p.FirstName} {p.LastName}")).ToListAsync();

        //public override void Update(Person entity)
        //{
        //    _context.Entry(entity).State = EntityState.Modified;

        //    foreach (var relation in entity.Relations)
        //    {
        //        if (relation.Id > 0)
        //            _context.Entry(relation).State = EntityState.Modified;
        //        else
        //            _context.Entry(relation).State = EntityState.Added;
        //    }

        //    foreach (var phoneNumber in entity.PhoneNumbers)
        //    {
        //        if (phoneNumber.Id > 0)
        //            _context.Entry(phoneNumber).State = EntityState.Modified;
        //        else
        //            _context.Entry(phoneNumber).State = EntityState.Added;
        //    }
        //}
        #endregion

        #region Private Methods
        private IQueryable<Person> GetWithIncludes(bool withTracking = false)
        {
            var table = withTracking ? Table : TableNoTracking;
            return table
                .Include(p => p.City)
                .Include(p => p.PhoneNumbers)
                .Include(p => p.Relations)
                .ThenInclude(r => r.RelatedPerson);
        }
        #endregion
    }
}
