using BlazingShop.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazingShop.Client.Service
{
    public interface IProductService
    {
        List<Product> Products { get; set; }

        Task LoadProductsAsync(string categoryUrl = null);

        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> SearhProductsAsync(string searchText);
    }
}
