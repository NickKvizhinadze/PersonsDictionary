using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PersonsDictionary.Localization;

namespace PersonsDictionary.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        #endregion

        #region Constructor
        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        #endregion

        #region Methods
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $" {ErrorMessages.InternalServerError} | Path = {context.Request.Path}.");
                throw;
            }
        }
        #endregion
    }
}
