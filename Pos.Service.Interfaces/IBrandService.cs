using Pizza.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Interfaces
{
    public interface IBrandService
    {
        Task<Brand> AddBrand(Brand brand);
        Task<Brand> UpdateBrand(int brandId, Brand brand);
        Task<IEnumerable<Brand>> GetAllActiveBrand();
    }
}
