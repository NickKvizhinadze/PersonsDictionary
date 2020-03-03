using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PersonsDictionary.Api.Common;
using PersonsDictionary.Application.Reports.Abstractions;
using PersonsDictionary.Application.Reports.Models.Dtos;

namespace PersonsDictionary.Api.Reports.Controllers
{
    public class ReportsController : BaseApiController
    {
        #region Fileds
        private readonly IReportsService _service;
        #endregion

        #region Constructor
        public ReportsController(IReportsService service)
        {
            _service = service;
        }
        #endregion

        #region Methods
        [HttpGet("[action]")]
        public async Task<ActionResult<List<PersonsRelationsCountByTypeDto>>> GetPersonsRelationsCountByType()
        {
            return Ok(await _service.GetPersonsRelationsCountByType());
        }
        #endregion
    }
}
