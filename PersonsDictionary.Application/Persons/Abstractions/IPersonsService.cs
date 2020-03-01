using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PersonsDictionary.Common.Models;
using PersonsDictionary.Application.Persons.Models;

namespace PersonsDictionary.Application.Persons.Abstractions
{
    public interface IPersonsService
    {
        Task<PersonDto> GetByIdAsync(int id);
        Task<Result<int>> UpdateAsync(PersonCreateRequest model, int id = 0);
        Task<Result> DeleteAsync(int id, string webRoot);
        Task<Result<string>> UploadPhotoAsync(int id, IFormFile image, string webRootDir);
        Task<Result<int>> AddedRelatedPersonAsync(int id, RelatedPersonCreateRequest model);
        Task<Result> DeleteRelationAsync(int id);
    }
}
