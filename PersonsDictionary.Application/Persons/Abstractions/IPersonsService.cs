using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PersonsDictionary.Common.Models;
using PersonsDictionary.Application.Persons.Models;

namespace PersonsDictionary.Application.Persons.Abstractions
{
    public interface IPersonsService
    {
        Task<ListResult<PersonDto>> GetAllAsync(string searchValue, Paging paging);
        Task<ListResult<PersonDto>> GetAllAsync(PersonFilter filter, Paging paging);
        Task<PersonDto> GetByIdAsync(int id);
        Task<Result<int>> InsertAsync(PersonCreateRequest model);
        Task<Result<int>> UpdateAsync(int id, PersonCreateRequest model);
        Task<Result> DeleteAsync(int id, string webRoot);
        Task<Result<string>> UploadPhotoAsync(int id, IFormFile image, string webRootDir);
        Task<Result<int>> AddedRelatedPersonAsync(int id, RelatedPersonCreateRequest model);
        Task<Result> DeleteRelationAsync(int id);
    }
}
