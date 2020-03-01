using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonsDictionary.Api.Attributes;
using PersonsDictionary.Api.Controllers;
using PersonsDictionary.Api.Persons.Models;
using PersonsDictionary.Application.Persons.Models;
using PersonsDictionary.Application.Persons.Abstractions;

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
        public async Task<IActionResult> Create([FromBody] PersonCreateViewModel model)
        {            
            var result = await _service.UpdateAsync(_mapper.Map<PersonCreateRequest>(model));

            return CustomResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PersonCreateViewModel model)
        {
            var result = await _service.UpdateAsync(_mapper.Map<PersonCreateRequest>(model), id);

            return CustomResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id, _env.ContentRootPath);

            return CustomResult(result);
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> UploadPhoto(int id, [FromForm] IFormFile image)
        {
            var result = await _service.UploadPhotoAsync(id, image, _env.ContentRootPath);
            return CustomResult(result);
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> Relatation(int id, [FromBody] RelatedPersonCreateViewModel model)
        {
            var result = await _service.AddedRelatedPersonAsync(id, _mapper.Map<RelatedPersonCreateRequest>(model));
            return CustomResult(result);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Relatation(int id)
        {
            var result = await _service.DeleteRelationAsync(id);
            return CustomResult(result);
        }
        #endregion
    }
}
