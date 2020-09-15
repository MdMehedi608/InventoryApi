using Pizza.Domain.Entities.DataModel;
using Pizza.Domain.Interfaces;
using Pos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> AddProduct(Product product)
        {
            try
            {
                return await _productRepository.AddProduct(product);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public async Task<Product> UpdateProduct(int productId, Product product)
        {
            try
            {
                return await _productRepository.UpdateProduct(productId, product);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<Product>> GetAllActiveProduct()
        {
            try
            {
                return await _productRepository.GetAllActiveProduct();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}
