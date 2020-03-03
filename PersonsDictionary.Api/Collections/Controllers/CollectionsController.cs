using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PersonsDictionary.Api.Common;
using PersonsDictionary.Application.Collections.Models;
using PersonsDictionary.Application.Collections.Abstractions;

namespace PersonsDictionary.Api.Collections.Controllers
{
    public class CollectionsController : BaseApiController
    {
        #region Fields
        private readonly ICollectionsService _service;
        #endregion

        #region Constructor
        public CollectionsController(ICollectionsService service)
        {
            _service = service;
        }
        #endregion

        #region Actions
        [HttpGet("Persons")]
        public async Task<ActionResult<List<CollectionDto<int>>>> GetPersons()
        {
            var result = await _service.GetPersonsAsync();
            return Ok(result);
        }

        [HttpGet("Genders")]
        public ActionResult<List<CollectionDto<int>>> GetGenders()
        {
            var result = _service.GetGenders();
            return Ok(result);
        }

        [HttpGet("PhoneNumberTypes")]
        public ActionResult<List<CollectionDto<int>>> GetPhoneNumberTypes()
        {
            var result = _service.GetPhoneNumberTypes();
            return Ok(result);
        }

        [HttpGet("PersonRelationTypes")]
        public ActionResult<List<CollectionDto<int>>> GetPersonRelationTypes()
        {
            var result = _service.GetPersonRelationTypes();
            return Ok(result);
        }
        #endregion
    }
}
