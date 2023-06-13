using AutoMapper;
using Klir.TechChallenge.Web.Api.DTO;
using Klir.TechChallenge.Web.Api.Repository;
using System.Collections.Generic;
using System.Linq;

namespace Klir.TechChallenge.Web.Api.Services
{


    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public List<CartItemDTO> GetCartItems()
        {
            var items = _cartRepository.GetCartItemsAsync().Result;
            return _mapper.Map<List<CartItemDTO>>(items.ToList());
        }

        public CartItemDTO AddProductToCart(int productId)
        {
            var item = _cartRepository.AddToCartAsync(productId).Result;
            return _mapper.Map<CartItemDTO>(item);
        }

        public bool RemoveProductFromCart(int productId)
        {
            var productInCart = _cartRepository.GetCartItemAsync(productId).Result;
            if (productInCart == null)
            {
                throw new KeyNotFoundException("The product id does not exist in the cart.");
            }

            _cartRepository.RemoveFromCartAsync(productId).ConfigureAwait(false);
            return true;
        }
    }
}
