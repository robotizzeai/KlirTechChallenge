using Klir.TechChallenge.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Api.Repository
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product GetProduct(int id);
    }
}
