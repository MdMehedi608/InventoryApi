using Pizza.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(int categoryId, Category category);
        Task<IEnumerable<Category>> GetAllActiveCategory();
    }
}
