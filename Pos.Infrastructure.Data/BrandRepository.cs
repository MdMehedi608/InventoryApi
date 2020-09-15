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
    public class BrandRepository:IBrandRepository
    {
        private readonly SqlServerContext _sqlServerConnection;
        public BrandRepository(SqlServerContext sqlServerConnection)
        {
            _sqlServerConnection = sqlServerConnection ?? throw new ArgumentNullException(nameof(sqlServerConnection));
        }
        public async Task<Brand> AddBrand(Brand brand)
        {

            
            using (var transaction = _sqlServerConnection.Database.BeginTransaction())
            {
                try
                {
                    var entity = await _sqlServerConnection.Brands.FirstOrDefaultAsync(item => item.BrandName == brand.BrandName);
                    if (entity == null)
                    {
                        await _sqlServerConnection.Brands.AddRangeAsync(brand);
                        await _sqlServerConnection.SaveChangesAsync();
                    }
                    else
                    {
                        brand.BrandId = 0;
                        brand.CountryId = 0;
                        brand.BrandName = "";
                        brand.BrandCode = "";
                        brand.IsActive = false;
                        brand.CreatedDate = DateTime.Now;
                        brand.CreatedBy = 0;
                        brand.UpdatedBy = 0;
                        brand.UpdatedDate = DateTime.Now;
                    }
                    transaction.Commit();
                    return brand;

                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }
        }
        public async Task<Brand>UpdateBrand(int brandId, Brand brand)
        {
            using(var transaction = _sqlServerConnection.Database.BeginTransaction())
            {
                try
                {
                    var entity = await _sqlServerConnection.Brands.FirstOrDefaultAsync(item => item.BrandId == brandId);
                    if (entity != null)
                    {
                        entity.BrandName = brand.BrandName;
                        entity.BrandCode = brand.BrandCode;
                        entity.CountryId = brand.CountryId;
                        entity.IsActive = brand.IsActive;
                        entity.CreatedBy = brand.CreatedBy;
                        entity.CreatedDate = brand.CreatedDate;
                        entity.UpdatedBy = brand.UpdatedBy;
                        entity.UpdatedDate = brand.UpdatedDate;
                        _sqlServerConnection.Brands.Update(entity);
                        await _sqlServerConnection.SaveChangesAsync();
                    }
                    else
                    {
                        entity.BrandId = 0;
                        entity.CountryId = 0;
                        entity.BrandName = "";
                        entity.BrandCode = "";
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
        public async Task<IEnumerable<Brand>> GetAllActiveBrand()
        {
            try
            {
                IQueryable<Brand> dataList = (from s in _sqlServerConnection.Brands
                                             where s.IsActive == true
                                             select new Brand
                                             {
                                                 BrandId = s.BrandId,
                                                 BrandName = s.BrandName,
                                                 BrandCode = s.BrandCode,
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
