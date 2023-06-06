namespace FirstWebApi.Contracts
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(int id);
        Task<Product> AddNewProduct(Product p);
        Task DeleteProduct(int productId);
    }
}
