using Pizza.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain.Interfaces
{
    public interface IBrandRepository
    {
        Task<Brand> AddBrand(Brand brand);
        Task<Brand> UpdateBrand(int brandId, Brand brand);
        Task<IEnumerable<Brand>> GetAllActiveBrand();
    }
}
