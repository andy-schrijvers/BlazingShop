using BlazingShop.Client.Service;
using BlazingShop.Shared;
using Blazored.LocalStorage;
using Blazored.Toast.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingShop.Client.CartServices
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCartAsync(ProductVariant productVariant);
        Task<List<CartItem>> GetCartItemsAsync();
        Task DeleteItemAsync(CartItem item);
    }

    public class CartService : ICartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IToastService _toestService;
        private readonly IProductService _productService;

        public event Action OnChange;

        public CartService(ILocalStorageService localStorage, IToastService toestService, IProductService productService)
        {
            _localStorage = localStorage;
            _toestService = toestService;
            _productService = productService;
        }

        public async Task AddToCartAsync(ProductVariant productVariant)
        {
            var cart = await _localStorage.GetItemAsync<List<ProductVariant>>("cart");

            if (cart == null)
            {
                cart = new List<ProductVariant>();
            }

            cart.Add(productVariant);
            await _localStorage.SetItemAsync("cart", cart);

            var product = await _productService.GetProductByIdAsync(productVariant.ProductId);
            _toestService.ShowSuccess(product.Title, "Added to cart");

            OnChange?.Invoke();
        }

        public async Task<List<CartItem>> GetCartItemsAsync()
        {
            var result = new List<CartItem>();
            var cart = await _localStorage.GetItemAsync<List<ProductVariant>>("cart");

            if (cart == null)
            {
                return result;
            }

            foreach (var item in cart)
            {
                var product = await _productService.GetProductByIdAsync(item.ProductId);
                var cartItem = new CartItem()
                {
                    ProductId = product.ProductId,
                    ProductTitle = product.Title,
                    Image = product.Image,
                    EditionId = item.EditionId
                };

                var variant = product.ProductVariants.Find(v => v.EditionId == item.EditionId);
                if (variant != null)
                {
                    cartItem.EditionName = variant.Edition?.Name;
                    cartItem.Price = variant.Price;
                }

                result.Add(cartItem);
            }

            return result;
        }

        public async Task DeleteItemAsync(CartItem item)
        {
            var cart = await _localStorage.GetItemAsync<List<ProductVariant>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(c => c.ProductId == item.ProductId && c.EditionId == item.EditionId);
            cart.Remove(cartItem);

            await _localStorage.SetItemAsync("cart", cart);
            OnChange?.Invoke();
        }
    }
}
