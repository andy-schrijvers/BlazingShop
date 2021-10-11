using BlazingShop.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Server.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();

        Task<Category> GetCategoryByUrlAsync(string categoryUrl);
    }
}
