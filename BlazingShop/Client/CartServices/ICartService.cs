using BlazingShop.Shared;
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
}
