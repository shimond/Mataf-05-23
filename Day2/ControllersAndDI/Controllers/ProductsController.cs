using FirstWebApi.Contracts;

namespace FirstWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    [HttpGet(Name = nameof(GetAllProducts))]
    [ProducesResponseType(200, Type = typeof(List<Product>))]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await this.productRepository.GetAllProducts();
        return this.Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await productRepository.GetProductById(id);
        if(result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }


    [HttpPost(Name = nameof(AddNewProduct))]
    [ProducesResponseType(200, Type = typeof(Product))]
    public async Task<ActionResult<Product>> AddNewProduct(Product p)
    {
        var newProductAfterInsert = await productRepository.AddNewProduct(p);
        return Created("products/" + newProductAfterInsert.Id, newProductAfterInsert);
    }

}




// Http/https
// Routing - mataf.com\api\controllerName - VERB
// VERB - POST, DELETE, GET, PUT, PATCH, OPTIONS, HEAD
// Status codes - 
// OK - 200, 201, 202, 204
// Client error - 400, 401, 403, 404, 405, 408, 409
// Server error - 500, 502, 504
