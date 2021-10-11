using BlazingShop.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingShop.Client.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;
        }

        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task LoadCategoriesAsync()
        {
            Categories = await _http.GetFromJsonAsync<List<Category>>("api/category");
        }
    }
}
