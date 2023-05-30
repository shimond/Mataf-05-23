using FirstWebApi.Model;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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





























