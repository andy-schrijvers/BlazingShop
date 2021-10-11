using BlazingShop.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazingShop.Server.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetProductsByCategoryUrlAsync(string categoryUrl);
        Task<Product> GetProductAsync(int productId);
    }
}
