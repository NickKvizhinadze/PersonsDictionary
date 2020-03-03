using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PersonsDictionary.Common.Models;

namespace PersonsDictionary.Api.Middlewares
{
    public class CultureMiddleware
    {
        #region Fields
        private readonly RequestDelegate _next;
        private readonly AppSettings _settings;
        #endregion

        #region Constructor
        public CultureMiddleware(RequestDelegate next, IOptions<AppSettings> options)
        {
            _next = next;
            _settings = options.Value;
        }
        #endregion

        #region Mthods
        public async Task Invoke(HttpContext context)
        {
            var cultureName = _settings.DefaultCulture;
            var queryCulture = context.Request.Headers["Accept-Language"].ToString();

            if (!string.IsNullOrWhiteSpace(queryCulture))
            {
                cultureName = queryCulture.Split(',')[0];
            }

            var culture = new CultureInfo(cultureName);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            await _next(context);
        }
        #endregion
    }
}
