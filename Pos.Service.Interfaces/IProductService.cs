using Pizza.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Interfaces
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(int productId, Product product);
        Task<IEnumerable<Product>> GetAllActiveProduct();
    }
}
