using Klir.TechChallenge.Web.Api.DTO;
using Klir.TechChallenge.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Repository
{
    public interface ICartRepository
    {
        Task<IEnumerable<CartItem>> GetCartItemsAsync();
        Task<CartItem> AddToCartAsync(int productId);
        Task RemoveFromCartAsync(int productId);
        Task<CartItem> GetCartItemAsync(int productId);
    }
}
