using FirstWebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet(Name = nameof(GetAllProducts))]
        [ProducesResponseType(200, Type= typeof(List<Product>))]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            await Task.Delay(1000);
            return this.Ok(9);
        }


        [HttpPost(Name = nameof(AddNewProduct))]
        [ProducesResponseType(200, Type = typeof(Product))]
        public Task<ActionResult<Product>> AddNewProduct(Product p)
        {
            return null;
        }

    }
}
