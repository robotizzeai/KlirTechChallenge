using Klir.TechChallenge.Web.Api.Models;
using Klir.TechChallenge.Web.Api.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Klir.TechChallenge.Web.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }
    }
}
