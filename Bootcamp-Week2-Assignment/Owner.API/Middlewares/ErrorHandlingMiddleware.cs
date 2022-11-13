using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;


namespace Owner.API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// The method that allows us to move on to the next pipeline
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception error)
            {
                await HandleException(httpContext, error);
            }
        }

        /// <summary>
        /// The method by which we manage exceptions
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        private async Task HandleException(HttpContext httpContext, Exception error)
        {
            var response = httpContext.Response;
            response.ContentType = "application/json";

            switch (error)
            {
                case BadHttpRequestException badHttpRequest:
                    // for bad requests cases
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case KeyNotFoundException keyNotFound:
                    // for key not found cases
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    // for unhandled errors cases
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            var result = JsonSerializer.Serialize(new { message = error.Message });
            await response.WriteAsync(result);
        }
    }
}
