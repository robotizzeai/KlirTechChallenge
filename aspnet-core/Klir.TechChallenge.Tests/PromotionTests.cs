using Klir.TechChallenge.Web.Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Klir.TechChallenge.Tests
{
    public class PromotionTests
    {
        [Fact]
        public void CalculatePrice_GivenQuantityOne_ReturnsUnitPrice()
        {
            var promotion = new BuyOneGetOneFreePromotion();
            decimal price = promotion.CalculatePrice(1, 20);
            Assert.Equal(20, price);
        }

        [Fact]
        public void CalculatePrice_GivenQuantityTwo_ReturnsUnitPrice()
        {
            var promotion = new BuyOneGetOneFreePromotion();
            decimal price = promotion.CalculatePrice(2, 20);
            Assert.Equal(20, price);
        }

        // Add more test cases for different quantities
    }

}

