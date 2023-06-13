using FirstWebApi.Model;
using FirstWebApi.Model.Config;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;

namespace FirstWebApi.Routes
{

    class MyEndPointFilter : IEndpointFilter
    {
        private readonly UserDetails _userDetails;

        public MyEndPointFilter(UserDetails userDetails)
        {
            _userDetails = userDetails;
        }
        public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            _userDetails.Name = "FROM ENDPOINT FILTER";
            return next(context);
        }
    }
    public static class ProductsRoutes
    {
        public static void MapProducts(this WebApplication app)
        {
            var group = app.MapGroup("Products")
                .WithTags("Products");

            group.MapGet("", GetAll)
                .AddEndpointFilter<MyEndPointFilter>();
                
            group.MapPost("", AddNewProduct);
            group.MapGet("{id}", GetProductByID);
            group.MapDelete("{id}", DeleteProduct);
        }

        private static async Task<NoContent> DeleteProduct(int id, IProductRepository repository)
        {
            await repository.DeleteProduct(id);
            return TypedResults.NoContent();
        }

        private static async Task<Ok<Product>> GetProductByID(int id, IProductRepository repository)
        {
            var res = await repository.GetProductById(id);
            return TypedResults.Ok(res);
        }
        private static async Task<Created<Product>> AddNewProduct(Product item, IProductRepository repository)
        {
            var res = await repository.AddNewProduct(item);
            return TypedResults.Created($"Products/{res.Id}", res);
        }

        private static async Task<Results<Ok<List<Product>>, NoContent>> GetAll(UserDetails us,  IProductRepository repository)
        {
            var res = await repository.GetAllProducts();
            if (res.Count() > 0)
            {
                return TypedResults.Ok(res);
            }
            return TypedResults.NoContent();
        }
    }
}
