using Microsoft.AspNetCore.Builder;
using Owner.API.Middlewares;

namespace Owner.API.Extensions
{
    public static class ErrorHandlingMiddlewareExtensions
    {
        /// <summary>
        /// With the Extension method, we add our custom method under IApplicationBuilder.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<ErrorHandlingMiddleware>();
            }
    }
}
