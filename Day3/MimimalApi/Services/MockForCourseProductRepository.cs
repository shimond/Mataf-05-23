using FirstWebApi.Contracts;
using FirstWebApi.Exceptions;
using FirstWebApi.Model.Config;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Validations;

namespace FirstWebApi.Services
{
    public class MockForCourseProductRepository : IProductRepository
    {
        private List<Product> _list = new() {
                new () { Id = 1 , Name ="Bamba", Price = 12.6},
                new () { Id = 2 , Name ="Kefli boded", Price = 1.6},
                new() { Id = 3, Name = "Doritos mini", Price = 0.6 }
            };
        private MtfServerConfig _mtfServerConfig;

        public MockForCourseProductRepository(
          
            IOptionsMonitor<MtfServerConfig> mtfConfigOption)
        {
            _mtfServerConfig = mtfConfigOption.CurrentValue;

            mtfConfigOption.OnChange((configValue, s) => {
                _mtfServerConfig = configValue;
            });
        }

        public Task<Product> AddNewProduct(Product p)
        {
            var lastId = this._list.Max(x => x.Id);
            var newProduct = p with { Id = lastId + 1 };
            this._list.Add(newProduct);
            return Task.FromResult(newProduct);
        }

        public Task DeleteProduct(int productId)
        {
            var productToDelete = _list.FirstOrDefault(x => x.Id == productId);
            if (productToDelete != null)
            {
                this._list.Remove(productToDelete);
                return Task.CompletedTask;
            }
            else
            {
                throw new CrudException("Cannot Delete item", CrudExceptionType.Conflict);
            }

        }

        public async Task<List<Product>> GetAllProducts()
        {
            await Task.Delay(1000);
            return _list;
        }

        public Task<Product?> GetProductById(int id)
        {
            var r = _list.FirstOrDefault(o => o.Id == id);
            return Task.FromResult(r);
        }

        public Task<Product> UpdateProduct(int id, Product productToUpdate)
        {
            if(!this._list.Any(x=>x.Id == id))
            {
                throw new CrudException("Cannot Update item", CrudExceptionType.Conflict);
            }
            this._list = this._list.Select(x =>
            {
                if (x.Id != id)
                {
                    return x;
                }
                else
                {
                    return x with { Name = productToUpdate.Name, Price = productToUpdate.Price };
                }
            }).ToList();

            return Task.FromResult(this._list.First(x => x.Id == id));
        }
    }
}
