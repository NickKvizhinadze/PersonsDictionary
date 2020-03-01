using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PersonsDictionary.Common.Models;

namespace PersonsDictionary.Application.Persons
{
    public interface IPersonsService
    {
        Task<Result<int>> UpdateAsync(PersonCreateRequest model, int id = 0);
        Task<Result> DekteAsync(int id, string webRoot);
        Task<Result<string>> UploadPhotoAsync(int id, IFormFile image, string webRootDir);
    }
}
