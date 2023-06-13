using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Api.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
