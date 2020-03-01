using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PersonsDictionary.Api.Attributes;
using PersonsDictionary.Api.Controllers;
using PersonsDictionary.Application.Persons;

namespace PersonsDictionary.Api.Persons
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
        public async Task<IActionResult> CreatePerson([FromForm] PersonCreateViewModel model)
        {            
            var result = await _service.AddAsync(_mapper.Map<PersonCreateRequest>(model), _env.ContentRootPath);

            return CustomResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromForm] PersonCreateViewModel model)
        {
            var result = await _service.AddAsync(_mapper.Map<PersonCreateRequest>(model), _env.ContentRootPath, id);

            return CustomResult(result);
        }
        #endregion
    }
}
