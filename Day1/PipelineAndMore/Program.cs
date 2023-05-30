using PipelineAndMore.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMatafHeaderCheckerMiddleware();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("  MIDD A 1  ");
    await next();
    await context.Response.WriteAsync("  MIDD A 2  ");
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("  MIDD B 1  ");
    await next();
    await context.Response.WriteAsync("  MIDD B 2  ");
});


app.Run(async context =>
{
    await context.Response.WriteAsync("  MY APPLICATION  ");
});

app.Run();
