using Models;

namespace SalesManager.API.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductAsync(string value);

        Task<Product> GetProductByIdAsync(int productId);

        Task InsertAsync(Product product);

        Task UpdateAsync(Product product);

        Task DeleteAsync(Product product);

        Task<bool> ExistsAsync(int productId);

        Task<bool> ExistsByNameAsync(string productName);

        Task<bool> ExistsByNameUpdateAsync(string productName, int productId);


    }
}