using System.Threading.Tasks;
using System.Collections.Generic;
using PersonsDictionary.Common.Models;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Application.Common;

namespace PersonsDictionary.Application.Persons.Abstractions
{
    public interface IPersonsRepository : IBaseRepository<Person, int>
    {
        Task<string> GetImageUrlAsync(int id);
        Task<(List<Person> persons, int totalCount)> GetAllAsync(string searchValue, Paging paging);
    }
}
