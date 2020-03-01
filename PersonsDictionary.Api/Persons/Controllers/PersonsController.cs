using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonsDictionary.Api.Attributes;
using PersonsDictionary.Api.Controllers;
using PersonsDictionary.Api.Persons.Models;
using PersonsDictionary.Application.Persons;

namespace PersonsDictionary.Api.Persons.Controllers
{
    public class PersonsController : BaseApiController
    {
        #region Fields
        private readonly IPersonsService _service;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        #endregion

        #region Constructor
        public PersonsController(IPersonsService service, IMapper mapper, IWebHostEnvironment env)
        {
            _service = service;
            _mapper = mapper;
            _env = env;
        }
        #endregion

        #region Actions
        [HttpPost]
        [ModelState]
        public async Task<IActionResult> CreatePerson([FromBody] PersonCreateViewModel model)
        {
            
            var result = await _service.UpdateAsync(_mapper.Map<PersonCreateRequest>(model));

            return CustomResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] PersonCreateViewModel model)
        {
            var result = await _service.UpdateAsync(_mapper.Map<PersonCreateRequest>(model), id);

            return CustomResult(result);
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> UploadPhoto(int id, [FromForm] IFormFile image)
        {
            var result = await _service.UploadPhotoAsync(id, image, _env.ContentRootPath);
            return CustomResult(result);
        }
        #endregion
    }
}
