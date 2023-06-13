using Klir.TechChallenge.Web.Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IPromotionStrategy Promotion { get; set; }
    }
}
