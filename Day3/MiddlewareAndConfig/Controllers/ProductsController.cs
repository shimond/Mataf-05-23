// appsettings.json
// appsettings.{ENV}.json
// env variables
// command line args
// user secrets - only in development

using FirstWebApi.Model.Config;
using Microsoft.Extensions.Options;

namespace FirstWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly MtfServerConfig _configMtfServer;
    private readonly IProductRepository _productRepository;
    private readonly IConfiguration _configuration;

    public ProductsController(
        IOptionsSnapshot<MtfServerConfig> mtfConfigOption,
        IProductRepository productRepository,
        IConfiguration configuration)
    {
        this._configMtfServer = mtfConfigOption.Value;

        this._productRepository = productRepository;
        this._configuration = configuration;
    }

    [HttpGet("config", Name = nameof(GetValueFromConfig))]
    public IActionResult GetValueFromConfig()
    {
        //var r = _configuration["mtfComplex:name"];
        //var r = _configuration["testFromSecret"];
        return Ok(this._configMtfServer);
    }

    [HttpGet(Name = nameof(GetAllProducts))]
    [ProducesResponseType(200, Type = typeof(List<Product>))]
    public async Task<IActionResult> GetAllProducts()
    {
        var result = await this._productRepository.GetAllProducts();
        return this.Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _productRepository.GetProductById(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }


    [HttpPost(Name = nameof(AddNewProduct))]
    [ProducesResponseType(200, Type = typeof(Product))]
    public async Task<ActionResult<Product>> AddNewProduct(Product p)
    {
        var newProductAfterInsert = await _productRepository.AddNewProduct(p);
        return Created("products/" + newProductAfterInsert.Id, newProductAfterInsert);
    }

    [HttpDelete("{id}", Name = nameof(DeleteProduct))]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productRepository.DeleteProduct(id);
        return NoContent();
    }

    [HttpPut("{id}", Name = nameof(UpdateProduct))]
    public async Task<IActionResult> UpdateProduct(int id, Product productToUpdate)
    {
        Product product = await _productRepository.UpdateProduct(id, productToUpdate);
        return Ok(product);
    }


}
