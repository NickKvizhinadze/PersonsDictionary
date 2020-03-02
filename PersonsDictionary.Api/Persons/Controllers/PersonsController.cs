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
using PersonsDictionary.Common.Models;
using Microsoft.Extensions.Options;

namespace PersonsDictionary.Api.Persons.Controllers
{
    public class PersonsController : BaseApiController
    {
        #region Fields
        private readonly IPersonsService _service;
        private readonly IMapper _mapper;
        private readonly AppSettings _settings;
        private readonly IWebHostEnvironment _env;
        #endregion

        #region Constructor
        public PersonsController(IPersonsService service, IMapper mapper, IOptions<AppSettings> options, IWebHostEnvironment env)
        {
            _service = service;
            _mapper = mapper;
            _settings = options.Value;
            _env = env;
        }
        #endregion

        #region Actions
        [HttpGet]
        public async Task<ActionResult<ListResult<PersonDto>>> GetAll(string searchValue, int page = 1)
        {
            var result = await _service.GetAllAsync(searchValue, new Paging(page, _settings.PerPage));
            return Ok(result);
        }

        [HttpGet("Filter")]
        public async Task<ActionResult<ListResult<PersonDto, PersonFilter>>> GetAll(PersonFilter filter, int page = 1)
        {
            var result = await _service.GetAllAsync(filter, new Paging(page, _settings.PerPage));
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> Get(int id)
        {
            var result = await _service.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        [ModelState]
        public async Task<ActionResult<int>> Create([FromBody] PersonCreateViewModel model)
        {            
            var result = await _service.UpdateAsync(_mapper.Map<PersonCreateRequest>(model));

            return CustomResult(result);
        }

        [HttpPut("{id}")]
        [ModelState]
        public async Task<ActionResult<int>> Update(int id, [FromBody] PersonCreateViewModel model)
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
        public async Task<ActionResult<string>> UploadPhoto(int id, [FromForm] IFormFile image)
        {
            var result = await _service.UploadPhotoAsync(id, image, _env.ContentRootPath);
            return CustomResult(result);
        }

        [HttpPost("[action]/{id}")]
        [ModelState]
        public async Task<ActionResult<int>> Relatation(int id, [FromBody] RelatedPersonCreateViewModel model)
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
