using Microsoft.AspNetCore.Builder;

namespace PersonsDictionary.Api.Middlewares
{
    public static class MiddlewareExtentions
    {
        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
        public static IApplicationBuilder UseCultureFromHeader(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CultureMiddleware>();
        }
    }
}
