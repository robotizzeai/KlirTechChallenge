using Klir.TechChallenge.Web.Api.Domain;
using Klir.TechChallenge.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Klir.TechChallenge.Web.Api.Repository
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Product A", Price = 20, Promotion = new BuyOneGetOneFreePromotion() },
        new Product { Id = 2, Name = "Product B", Price = 4, Promotion = new ThreeForTenPromotion() },
        new Product { Id = 3, Name = "Product C", Price = 2, Promotion = new NoPromotion() },
        new Product { Id = 4, Name = "Product D", Price = 4, Promotion = new ThreeForTenPromotion() },
    };

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }
    }
}
