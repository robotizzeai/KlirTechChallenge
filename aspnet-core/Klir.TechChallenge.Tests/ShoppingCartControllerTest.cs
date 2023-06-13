using Klir.TechChallenge.Web.Api.Controllers;
using Klir.TechChallenge.Web.Api.Domain;
using Klir.TechChallenge.Web.Api.Models;
using Klir.TechChallenge.Web.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Klir.TechChallenge.Tests
{
    public class ShoppingCartControllerTest
    {
        [Fact]
        public void GetProducts_ReturnsProductList()
        {
            // Arrange
            var mockProductService = new Mock<IProductService>();
            var mockCartService = new Mock<ICartService>();
            var mockCheckoutService = new Mock<ICheckoutService>();

            mockProductService.Setup(service => service.GetProducts())
                .Returns(new List<Product>
                {
                new Product { Id = 1, Name = "Product A", Price = 20, Promotion = new BuyOneGetOneFreePromotion() },
                new Product { Id = 2, Name = "Product B", Price = 4, Promotion = new ThreeForTenPromotion() },
                new Product { Id = 3, Name = "Product C", Price = 2 },
                new Product { Id = 4, Name = "Product D", Price = 4, Promotion = new ThreeForTenPromotion() },
                });

            var controller = new ShoppingCartController(mockProductService.Object, mockCartService.Object, mockCheckoutService.Object);

            // Act
            var result = controller.GetProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var products = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(4, products.Count);
        }

        // Add more tests for other methods of ShoppingCartController
    }
}
