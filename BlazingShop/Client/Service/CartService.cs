using BlazingShop.Client.Service;
using BlazingShop.Shared;
using Blazored.LocalStorage;
using Blazored.Toast.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazingShop.Client.Service
{
    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toestService;
        private readonly IProductService _productService;
        private readonly HttpClient _http;

        public event Action OnChange;

        public CartService(ILocalStorageService localStorage, IToastService toestService, IProductService productService, HttpClient http)
        {
            _localStorage = localStorage;
            _toestService = toestService;
            _productService = productService;
           _http = http;
        }

        public async Task AddToCartAsync(CartItem cartItem)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");

            if (cart == null)
            {
                cart = new List<CartItem>();
            }

            var sameItem = cart
                .Find(x => x.ProductId == cartItem.ProductId && x.EditionId == cartItem.EditionId);

            if (sameItem == null)
            {
                cart.Add(cartItem);
            }

            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await _localStorage.SetItemAsync("cart", cart);


            var product = await _productService.GetProductByIdAsync(cartItem.ProductId);
            _toestService.ShowSuccess(product.Title, "Added to cart");

            OnChange?.Invoke();
        }

        public async Task<List<CartItem>> GetCartItemsAsync()
        {

            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");

            if (cart == null)
            {
                return new List<CartItem>();
            }

            return cart;
        }

        public async Task DeleteItemAsync(CartItem item)
        {
            var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(c => c.ProductId == item.ProductId && c.EditionId == item.EditionId);
            cart.Remove(cartItem);

            await _localStorage.SetItemAsync("cart", cart);
            OnChange?.Invoke();
        }

        public async Task EmptyCart()
        {
            await _localStorage.RemoveItemAsync("cart");
            OnChange?.Invoke();
        }

        public async Task<string> Checkout()
        {
            var result = await _http.PostAsJsonAsync("/api/payment/checkout", await GetCartItemsAsync());
            var url = await result.Content.ReadAsStringAsync();
            return url;
        }
    }
}
