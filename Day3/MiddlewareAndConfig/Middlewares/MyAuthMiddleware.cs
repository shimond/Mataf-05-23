
namespace FirstWebApi.Middlewares;

public class MyAuthMiddleware
{
    private readonly RequestDelegate _next;

    public MyAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, UserAuth u)
    {
        await _next(httpContext);
        //if (httpContext.Request.Headers.ContainsKey("username")
        //    && httpContext.Request.Headers.ContainsKey("password"))
        //{
        //    u.UserName = httpContext.Request.Headers["username"].ToString();
        //    u.Password = httpContext.Request.Headers["password"].ToString();
        //    await _next(httpContext);
        //}
        //else
        //{
        //    httpContext.Response.StatusCode = 401;
        //    httpContext.Response.ContentType = "text/plain";
        //    await httpContext.Response.WriteAsync("Header missing");
        //}
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class MyAuthMiddlewareExtensions
{
    public static IApplicationBuilder UseMyAuthMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyAuthMiddleware>();
    }
}
