using FirstWebApi.Model.Config;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<MtfServerConfig>(builder.Configuration.GetSection("mtfServer"));

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProductRepository, MockForCourseProductRepository>();
builder.Services.AddScoped<UserDetails>();

var app = builder.Build();
app.UseSetNameInAppMiddleware();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCurdErrorHandlerMiddleware();
app.UseHttpsRedirection();
app.MapProducts();
app.Run();
