using Klir.TechChallenge.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Api.Services
{
    public interface IProductService
    {
        Product GetProduct(int productId);
        List<Product> GetProducts();
    }
}
