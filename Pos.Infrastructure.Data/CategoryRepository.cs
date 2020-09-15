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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public CategoryRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }
        public async Task<Category> AddCategory(Category category)
        {


            using (var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    var entity = await _sqlServerContext.Categories.FirstOrDefaultAsync(item => item.CategoryName == category.CategoryName);
                    if (entity == null)
                    {
                        await _sqlServerContext.Categories.AddRangeAsync(category);
                        await _sqlServerContext.SaveChangesAsync();
                    }
                    else
                    {
                        category.CategoryId = 0;
                        category.CategoryName = "";
                        category.IsActive = false;
                        category.CreatedDate = DateTime.Now;
                        category.CreatedBy = 0;
                        category.UpdatedBy = 0;
                        category.UpdatedDate = DateTime.Now;
                    }
                    transaction.Commit();
                    return category;

                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }
        }
        public async Task<Category> UpdateCategory(int categoryId, Category category)
        {
            using (var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    var entity = await _sqlServerContext.Categories.FirstOrDefaultAsync(item => item.CategoryId == categoryId);
                    if (entity != null)
                    {
                        entity.CategoryName = category.CategoryName;
                        entity.IsActive = category.IsActive;
                        entity.CreatedBy = category.CreatedBy;
                        entity.CreatedDate = category.CreatedDate;
                        entity.UpdatedBy = category.UpdatedBy;
                        entity.UpdatedDate = category.UpdatedDate;
                        _sqlServerContext.Categories.Update(entity);
                        await _sqlServerContext.SaveChangesAsync();
                    }
                    else
                    {
                        entity.CategoryId = 0;
                        entity.CategoryName = "";
                        entity.IsActive = false;
                        entity.CreatedDate = DateTime.Now;
                        entity.CreatedBy = 0;
                        entity.UpdatedBy = 0;
                        entity.UpdatedDate = DateTime.Now;
                    }
                    transaction.Commit();
                    return entity;

                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }

        }
        public async Task<IEnumerable<Category>> GetAllActiveCategory()
        {
            try
            {
                IQueryable<Category> dataList = (from s in _sqlServerContext.Categories
                                              where s.IsActive == true
                                              select new Category
                                              {
                                                  CategoryId = s.CategoryId,
                                                  CategoryName = s.CategoryName,
                                                  IsActive = s.IsActive,
                                                  CreatedDate = s.CreatedDate,
                                                  CreatedBy = s.CreatedBy,
                                                  UpdatedBy = s.UpdatedBy,
                                                  UpdatedDate = s.UpdatedDate
                                              });
                return await dataList.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
