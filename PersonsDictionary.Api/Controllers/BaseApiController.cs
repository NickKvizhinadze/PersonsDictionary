﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PersonsDictionary.Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PersonsDictionary.Api.Controllers
{
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        #region Protected Methods
        protected IActionResult CustomResult<T>(Result<T> result)
        {
            if (!result.Succeeded)
                return ReturnErrorResult(result);

            return Ok(result.Data);
        }

        protected IActionResult CustomResult(Result result)
        {
            if (!result.Succeeded)
                return ReturnErrorResult(result);
            
            return NoContent();
        }
        #endregion

        #region Private Methods
        private IActionResult ReturnErrorResult(Result result)
        {
            AddErrors(result.Errors);
            switch (result.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    return BadRequest(ModelState);
                default:
                    return StatusCode((int)result.StatusCode);
            }
        }

        protected void AddErrors(IEnumerable<KeyValuePair<string, string>> errors)
        {
            foreach (var error in errors)
                AddError(error);
        }

        protected void AddError(KeyValuePair<string, string> error)
        {
            ModelState.AddModelError(error.Key, error.Value);
        }

        protected string GetErrorsFromModelState(ModelStateDictionary modelState)
        {
            return string.Join("; ", modelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
        }

        #endregion
    }
}
