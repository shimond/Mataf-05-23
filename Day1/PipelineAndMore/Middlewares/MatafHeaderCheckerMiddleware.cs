namespace PipelineAndMore.Middlewares;

public class MatafHeaderCheckerMiddleware
{
    private readonly RequestDelegate _next;

    public MatafHeaderCheckerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Method == "POST" && context.Request.Headers.Keys.Contains("MATAF_KEY"))
        {
            await _next(context);
        }

        else
        {
            context.Response.StatusCode = 401;
        }
    }
}

public static class MatafHeaderCheckerMiddlewareExtensions
{
    public static IApplicationBuilder UseMatafHeaderCheckerMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MatafHeaderCheckerMiddleware>();
    }
}
