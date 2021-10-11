using BlazingShop.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingShop.Client.Service
{

    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Product>($"/api/product/{id}");
        }

        public async Task LoadProductsAsync(string categoryUrl = null)
        {
            if (categoryUrl == null)
            {
                Products = await _http.GetFromJsonAsync<List<Product>>($"/api/product");
            }

            else
            {
                Products = await _http.GetFromJsonAsync<List<Product>>($"/api/product/category/{categoryUrl}");
            }
        }
    }
}
