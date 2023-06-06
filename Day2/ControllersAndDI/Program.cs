using FirstWebApi.Contracts;
using FirstWebApi.Middlewares;
using FirstWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// resolve DI 
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProductRepository, MockForCourseProductRepository>();
//builder.Services.AddTransient<IProductRepository, MockForCourseProductRepository>();

var app = builder.Build();
app.UseCurdErrorHandlerMiddleware();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // CREATE JSON FILE BY CONTROLLERS
    app.UseSwaggerUI(); // CREATE THE UI OF THE SWAGGER
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();






//// Value types
//int? x = null;
//Nullable<int> x1 = null;

//x.GetValueOrDefault(45);
//Int32 x2 = null;
//decimal d = null;
//bool s = null;

//// reference types
//string? z = null;



////void Test(Product p)
////{
////    ////if(p!= null && p.FactoryAddress != null && p.FactoryAddress.Street == "Hashevi")
////    //if (p?.FactoryAddress?.Street == "Hashevi")
////    //{
////    //}
//}

//Product p = new() { Id = 2, Name = "Asd", Price = 123 };

//Console.WriteLine(p);










// var isOk =  dbManager.save(person)
// if(isOk){
//}

// dbManager.save(person)
// this.Ok("SABABA");

//Is, Has...
//Try


















