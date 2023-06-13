using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Api.Domain
{
    public interface IPromotionStrategy
    {
        string Name { get; }
        decimal CalculatePrice(int quantity, decimal unitPrice);
    }
}
