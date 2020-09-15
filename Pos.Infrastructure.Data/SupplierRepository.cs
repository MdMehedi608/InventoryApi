using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entities.DataModel;
using Pizza.Domain.Interfaces;
using Pos.Context.EfConnection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infrastructure.Data
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public SupplierRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }
        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            using(var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    var entity = await _sqlServerContext.Suppliers.FirstOrDefaultAsync(item => item.Phone == supplier.Phone);
                    if (entity == null)
                    {
                        await _sqlServerContext.AddRangeAsync(supplier);
                        await _sqlServerContext.SaveChangesAsync();
                    }
                    else
                    {
                        supplier.SupplierId = 0;
                        supplier.SupplierName = "";
                        supplier.CompanyId = 0;
                        supplier.CountryId = 0;
                        supplier.PostalCode = "";
                        supplier.VatNumber = "";
                        supplier.Email = "";
                        supplier.Phone = "";
                        supplier.Address = "";
                        supplier.City = "";
                        supplier.State = "";
                        supplier.IsActive = false;
                        supplier.CreatedDate = DateTime.Now;
                        supplier.CreatedBy = 0;
                        supplier.UpdatedBy = 0;
                        supplier.UpdatedDate = DateTime.Now;
                    }
                    transaction.Commit();
                    return supplier;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }

        }
        public async Task<Supplier> UpdateSupplier(int supplierId, Supplier supplier)
        {
            using (var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    var entity = await _sqlServerContext.Suppliers.FirstOrDefaultAsync(item => item.SupplierId == supplierId);
                    if (entity != null)
                    {
                        entity.SupplierName = supplier.SupplierName;
                        entity.CompanyId = supplier.CompanyId;
                        entity.CountryId = supplier.CountryId;
                        entity.PostalCode = supplier.PostalCode;
                        entity.VatNumber = supplier.VatNumber;
                        entity.Email = supplier.VatNumber;
                        entity.Phone = supplier.Phone;
                        entity.Address = supplier.Address;
                        entity.City = supplier.City;
                        entity.State = supplier.State;
                        entity.IsActive = supplier.IsActive;
                        entity.CreatedDate = supplier.CreatedDate;
                        entity.CreatedBy = supplier.CreatedBy;
                        entity.UpdatedBy = supplier.UpdatedBy;
                        entity.UpdatedDate = supplier.UpdatedDate;

                        _sqlServerContext.Update(entity);
                        await _sqlServerContext.SaveChangesAsync();
                    }
                    else
                    {
                        entity.SupplierId = 0;
                        entity.SupplierName = "";
                        entity.CompanyId = 0;
                        entity.CountryId = 0;
                        entity.PostalCode = "";
                        entity.VatNumber = "";
                        entity.Email = "";
                        entity.Phone = "";
                        entity.Address = "";
                        entity.City = "";
                        entity.State = "";
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
    }
}
