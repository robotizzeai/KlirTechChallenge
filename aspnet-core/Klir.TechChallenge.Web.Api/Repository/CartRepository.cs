using Klir.TechChallenge.Web.Api.Models;
using Klir.TechChallenge.Web.Api.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class CartRepository : ICartRepository
{
    private readonly Dictionary<int, CartItem> _cartItems;
    private readonly IProductRepository _productRepository;

    public CartRepository(IProductRepository productRepository)
    {
        _cartItems = new Dictionary<int, CartItem>();
        _productRepository = productRepository;
    }

    public Task<IEnumerable<CartItem>> GetCartItemsAsync()
    {
        return Task.FromResult(_cartItems.Values.AsEnumerable());
    }

    public Task<CartItem> AddToCartAsync(int productId)
    {
        if (_cartItems.TryGetValue(productId, out var existingItem))
        {
            existingItem.Quantity++;
            return Task.FromResult(existingItem);
        }
        else
        {
            var product = _productRepository.GetProduct(productId);
            CartItem newItem = new CartItem
            {
                Product = product,
                Quantity = 1
            };
            _cartItems.Add(productId, newItem);
            return Task.FromResult(newItem);
        }

    }

    public Task RemoveFromCartAsync(int productId)
    {
        if (_cartItems.TryGetValue(productId, out var existingItem))
        {
            existingItem.Quantity--;
            if (existingItem.Quantity <= 0)
            {
                _cartItems.Remove(productId);
            }
        }

        return Task.CompletedTask;
    }

    public Task<CartItem> GetCartItemAsync(int productId)
    {
        _cartItems.TryGetValue(productId, out var cartItem);
        return Task.FromResult(cartItem);
    }
}
