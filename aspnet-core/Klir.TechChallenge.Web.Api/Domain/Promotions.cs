using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Api.Domain
{
    public class NoPromotion : IPromotionStrategy
    {
        public string Name => "No Promotion";

        public decimal CalculatePrice(int quantity, decimal unitPrice)
        {
            return quantity * unitPrice;
        }
    }

    public class BuyOneGetOneFreePromotion : IPromotionStrategy
    {
        public string Name => "Buy 1 Get 1 Free";

        public decimal CalculatePrice(int quantity, decimal unitPrice)
        {
            int quantityToChargeFor = quantity / 2 + quantity % 2;
            return quantityToChargeFor * unitPrice;
        }
    }

    public class ThreeForTenPromotion : IPromotionStrategy
    {
        public string Name => "3 for 10 Euro";

        public decimal CalculatePrice(int quantity, decimal unitPrice)
        {
            int groupsOfThree = quantity / 3;
            int remaining = quantity % 3;
            return groupsOfThree * 10 + remaining * unitPrice;
        }
    }
}
