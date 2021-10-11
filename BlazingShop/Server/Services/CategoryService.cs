using BlazingShop.Server.Data;
using BlazingShop.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Server.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _data;
        public CategoryService(DataContext data)
        {
            _data = data;
        }   

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _data.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByUrlAsync(string categoryUrl)
        {
            return await _data.Categories.FirstOrDefaultAsync(c => c.Url.ToLower().Equals(categoryUrl.ToLower()));
        }
    }
}
