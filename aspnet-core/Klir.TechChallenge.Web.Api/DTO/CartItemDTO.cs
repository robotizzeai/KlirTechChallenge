using Klir.TechChallenge.Web.Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Api.DTO
{
    public class CartItemDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public string Promotion { get; set; }
    }
}
