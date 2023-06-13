using FirstWebApi.Model.Config;

var builder = WebApplication.CreateBuilder(args);

// Configuration: 

builder.Services.Configure<MtfServerConfig>(builder.Configuration.GetSection("mtfServer"));


// resolve DI:
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProductRepository, MockForCourseProductRepository>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<UserAuth>();


var app = builder.Build();

// Middleware pipeline:

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // CREATE JSON FILE BY CONTROLLERS
    app.UseSwaggerUI(); // CREATE THE UI OF THE SWAGGER
}

app.UseCurdErrorHandlerMiddleware();
//app.UseMyAuthMiddleware();


app.UseHttpsRedirection();

app.MapControllers();

app.Run();








