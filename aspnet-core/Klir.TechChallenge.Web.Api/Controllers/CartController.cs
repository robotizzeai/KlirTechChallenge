using Klir.TechChallenge.Web.Api.DTO;
using Klir.TechChallenge.Web.Api.Models;
using Klir.TechChallenge.Web.Api.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly ICheckoutService _checkoutService;

        public ShoppingCartController(IProductService productService, ICartService cartService, ICheckoutService checkoutService)
        {
            _productService = productService;
            _cartService = cartService;
            _checkoutService = checkoutService;
        }

        // Returns all available products
        [HttpGet("products")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        // Returns all items in the cart
        [HttpGet("cart")]
        public ActionResult<IEnumerable<CartItemDTO>> GetCartItems()
        {
            var cartItems = _cartService.GetCartItems();
            return Ok(cartItems);
        }

        // Adds a product to the cart
        [HttpPost("cart")]
        public ActionResult<CartItem> AddProductToCart(int productId)
        {
            var cartItem = _cartService.AddProductToCart(productId);
            return Created("CartItem", cartItem);
        }

        // Removes an item from the cart
        [HttpDelete("cart/{id}")]
        public IActionResult RemoveProductFromCart(int id)
        {
            var success = _cartService.RemoveProductFromCart(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // Returns the total price of the cart
        [HttpGet("checkout")]
        public ActionResult<decimal> GetTotalPrice()
        {
            var totalPrice = _checkoutService.CalculateTotalPrice();
            return Ok(totalPrice);
        }
    }
}
