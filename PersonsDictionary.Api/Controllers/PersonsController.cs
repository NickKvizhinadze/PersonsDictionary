using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonsDictionary.Api.Attributes;
using PersonsDictionary.Application.Persons;

namespace PersonsDictionary.Api.Controllers
{
    public class PersonsController : BaseApiController
    {
        #region Fields
        private readonly IPersonsService _service;
        private readonly IWebHostEnvironment _env;
        #endregion

        #region Constructor
        public PersonsController(IPersonsService service, IWebHostEnvironment env)
        {
            _service = service;
            _env = env;
        }
        #endregion

        #region Actions
        [HttpPost]
        [ModelState]
        public async Task<IActionResult> CreatePerson([FromForm] PersonCreateRequest model)
        {
            var result = await _service.AddAsync(model, _env.ContentRootPath);

            return CustomResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromForm] PersonCreateRequest model)
        {
            var result = await _service.AddAsync(model, _env.ContentRootPath, id);

            return CustomResult(result);
        }
        #endregion
    }
}
