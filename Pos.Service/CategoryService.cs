using Pizza.Domain.Entities.DataModel;
using Pizza.Domain.Interfaces;
using Pos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Category> AddCategory(Category category)
        {
            try
            {
                return await _categoryRepository.AddCategory(category);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<Category> UpdateCategory(int categoryId, Category category)
        {
            try
            {
                return await _categoryRepository.UpdateCategory(categoryId, category);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<Category>> GetAllActiveCategory()
        {
            try
            {
                return await _categoryRepository.GetAllActiveCategory();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
