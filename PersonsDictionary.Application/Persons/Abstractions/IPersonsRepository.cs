using System.Threading.Tasks;
using System.Collections.Generic;
using PersonsDictionary.Common.Models;
using PersonsDictionary.Domain.Persons;
using PersonsDictionary.Application.Common;
using PersonsDictionary.Application.Persons.Models;

namespace PersonsDictionary.Application.Persons.Abstractions
{
    public interface IPersonsRepository : IBaseRepository<Person, int>
    {
        Task<Person> GetByIdWithTrackingAsync(int id);
        Task<string> GetImageUrlAsync(int id);
        Task<(List<Person> persons, int totalCount)> GetAllAsync(string searchValue, Paging paging);
        Task<(List<Person> persons, int totalCount)> GetAllAsync(PersonFilter filter, Paging paging);
        Task<List<KeyValuePair<int, string>>> GetPersonsCollectionAsync();
    }
}
