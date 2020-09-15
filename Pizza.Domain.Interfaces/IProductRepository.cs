using Pizza.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(int productId, Product product);
        Task<IEnumerable<Product>> GetAllActiveProduct();
    }
}
