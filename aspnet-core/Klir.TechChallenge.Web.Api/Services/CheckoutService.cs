using Klir.TechChallenge.Web.Api.DTO;
using Klir.TechChallenge.Web.Api.Models;
using Klir.TechChallenge.Web.Api.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Api.Services
{
    public class CheckoutService : ICheckoutService
    {
        public CheckoutService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public ICartRepository _cartRepository { get; }

        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            var cartItems = _cartRepository.GetCartItemsAsync().ConfigureAwait(false);

            foreach (var cartItem in cartItems.GetAwaiter().GetResult())
            {
                int quantity = cartItem.Quantity;
                decimal unitPrice = cartItem.Product.Price;
                totalPrice += cartItem.Product.Promotion.CalculatePrice(quantity, unitPrice);
            }

            return totalPrice;
        }
    }
}
