using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entities.DataModel;
using Pizza.Domain.Interfaces;
using Pos.Context.EfConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public ProductRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }

        public async Task<Product> AddProduct(Product product)
        {
            
            using (var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    var entity = await _sqlServerContext.Products.FirstOrDefaultAsync(item => item.ProductName == product.ProductName);
                    if (entity == null)
                    {
                        await _sqlServerContext.AddRangeAsync(product);
                        await _sqlServerContext.SaveChangesAsync();
                        
                    }
                    else
                    {
                        product.ProductId = 0;
                        product.CategoryId = 0;
                        product.ProductName = "";
                        product.ProductCode = "";
                        product.SerialNo = "";
                        product.TypeId = 0;
                        product.UnitId = 0;
                        product.BrandId = 0;
                        product.ImageURL = "";
                        product.Cost = 0;
                        product.Price = 0;
                        product.Quantity = 0;
                        product.IsActive = false;
                        product.CreatedDate = DateTime.Now;
                        product.CreatedBy = 0;
                        product.UpdatedBy = 0;
                        product.UpdatedDate = DateTime.Now;

                    }
                    transaction.Commit();
                    return product;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }
            
        }

        public async Task<Product> UpdateProduct(int productId, Product product)
        {
            
            using (var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    var entity = await _sqlServerContext.Products.FirstOrDefaultAsync(item => item.ProductId == productId);
                    if (entity != null)
                    {
                        entity.CategoryId = product.CategoryId;
                        entity.ProductName = product.ProductName;
                        entity.ProductCode = product.ProductCode;
                        entity.SerialNo = product.SerialNo;
                        entity.TypeId = product.TypeId;
                        entity.UnitId = product.UnitId;
                        entity.BrandId = product.BrandId;
                        entity.ImageURL = product.ImageURL;
                        entity.Cost = product.Cost;
                        entity.Price = product.Price;
                        entity.Quantity = product.Quantity;
                        entity.IsActive = product.IsActive;
                        entity.CreatedDate = product.CreatedDate;
                        entity.CreatedBy = product.CreatedBy;
                        entity.UpdatedBy = product.UpdatedBy;
                        entity.UpdatedDate = product.UpdatedDate;

                        _sqlServerContext.Update(entity);
                        await _sqlServerContext.SaveChangesAsync();
                        transaction.Commit();
                    }
                    else
                    {
                        entity.ProductId = 0;
                        entity.CategoryId = 0;
                        entity.ProductName = "";
                        entity.ProductCode = "";
                        entity.SerialNo = "";
                        entity.TypeId = 0;
                        entity.UnitId = 0;
                        entity.BrandId = 0;
                        entity.ImageURL = "";
                        entity.Cost = 0;
                        entity.Price = 0;
                        entity.Quantity = 0;
                        entity.IsActive = false;
                        entity.CreatedDate = DateTime.Now;
                        entity.CreatedBy = 0;
                        entity.UpdatedBy = 0;
                        entity.UpdatedDate = DateTime.Now;

                    }                    
                    return entity;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }
            
        }
        public async Task<IEnumerable<Product>> GetAllActiveProduct()
        {
            try
            {
                IQueryable<Product> data = (from p in _sqlServerContext.Products
                                            where p.IsActive == true
                                            select new Product
                                            {
                                                ProductId = p.ProductId,
                                                ProductName = p.ProductName,
                                                ProductCode = p.ProductCode,
                                                CategoryId = p.CategoryId,
                                                SerialNo = p.SerialNo,
                                                TypeId = p.TypeId,
                                                UnitId = p.UnitId,
                                                BrandId = p.BrandId,
                                                ImageURL = p.ImageURL,
                                                Cost = p.Cost,
                                                Price = p.Price,
                                                Quantity = p.Quantity,
                                                IsActive = p.IsActive,
                                                CreatedBy = p.CreatedBy,
                                                CreatedDate = p.CreatedDate,
                                                UpdatedBy = p.UpdatedBy,
                                                UpdatedDate = p.UpdatedDate
                                            });
                return await data.ToListAsync();
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}
