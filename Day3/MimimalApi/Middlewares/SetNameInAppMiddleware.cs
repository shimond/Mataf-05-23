using FirstWebApi.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace FirstWebApi.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SetNameInAppMiddleware
    {
        private readonly RequestDelegate _next;

        public SetNameInAppMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, UserDetails userDetails)
        {
            userDetails.Name = "NAME FROM MIDDLEWARE";
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SetNameInAppMiddlewareExtensions
    {
        public static IApplicationBuilder UseSetNameInAppMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SetNameInAppMiddleware>();
        }
    }
}
