using System.Threading.Tasks;
using PersonsDictionary.Common.Models;

namespace PersonsDictionary.Application.Persons
{
    public interface IPersonsService
    {
        Task<Result<int>> AddAsync(PersonCreateRequest model, string webRootDir, int id = 0);
    }
}
