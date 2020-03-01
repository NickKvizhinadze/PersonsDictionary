using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PersonsDictionary.Common.Models;
using PersonsDictionary.Application.Persons.Models;

namespace PersonsDictionary.Application.Persons.Abstractions
{
    public interface IPersonsService
    {
        Task<Result<int>> UpdateAsync(PersonCreateRequest model, int id = 0);
        Task<Result> DekteAsync(int id, string webRoot);
        Task<Result<string>> UploadPhotoAsync(int id, IFormFile image, string webRootDir);
        Task<Result> AddedRelatedPersonAsync(int id, RelatedPersonCreateRequest model);
    }
}
