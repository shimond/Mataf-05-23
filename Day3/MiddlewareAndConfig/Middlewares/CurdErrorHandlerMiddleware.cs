using FirstWebApi.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FirstWebApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CurdErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CurdErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CrudException c)
            {
                if (c.ErrorType == CrudExceptionType.NotFound)
                {
                    httpContext.Response.StatusCode = 404;
                }
                else if (c.ErrorType == CrudExceptionType.Conflict)
                {
                    httpContext.Response.StatusCode = 409;
                    httpContext.Response.ContentType = "text/plain";
                    await httpContext.Response.WriteAsync(c.Message);

                }

            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CurdErrorHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCurdErrorHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CurdErrorHandlerMiddleware>();
        }
    }
}
