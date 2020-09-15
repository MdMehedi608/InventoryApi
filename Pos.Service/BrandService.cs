using Pizza.Domain.Entities.DataModel;
using Pizza.Domain.Interfaces;
using Pos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service
{
    public class BrandService:IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<Brand> AddBrand(Brand brand)
        {
            try
            {
                return await _brandRepository.AddBrand(brand);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<Brand> UpdateBrand(int brandId, Brand brand)
        {
            try
            {
                return await _brandRepository.UpdateBrand(brandId, brand);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<Brand>> GetAllActiveBrand()
        {
            try
            {
                return await _brandRepository.GetAllActiveBrand();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
