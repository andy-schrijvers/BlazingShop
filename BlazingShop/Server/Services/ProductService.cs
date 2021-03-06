using BlazingShop.Server.Data;
using BlazingShop.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _data;
        private readonly ICategoryService _categoryService;

        public ProductService(DataContext data, ICategoryService categoryService)
        {
            _data = data;
            _categoryService = categoryService;
        }
       

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _data.Products
                .Include(p => p.ProductVariants)
                .ToListAsync();
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            Product product = await _data.Products
                .Include(p => p.ProductVariants)
                .ThenInclude(pv => pv.Edition)
                .FirstOrDefaultAsync(p => p.ProductId == productId);

            product.Views++;

            await _data.SaveChangesAsync();

            return product;
        } 

        public async Task<List<Product>> GetProductsByCategoryUrlAsync(string categoryUrl)
        {
            Category category = await _categoryService.GetCategoryByUrlAsync(categoryUrl);

            return await _data.Products
                .Include(p => p.ProductVariants)
                .Where(p => p.CategoryId == category.CategoryId).ToListAsync();
        }

        public async Task<List<Product>> SearchProductsAsync(string searchText)
        {
            return await _data.Products
                .Where(p => p.Title.Contains(searchText) || p.Description.Contains(searchText))
                .ToListAsync();
        }
    }
}
