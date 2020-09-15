using Pizza.Domain.Entities.DataModel;
using Pizza.Domain.Interfaces;
using Pos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            try
            {
                return await _supplierRepository.AddSupplier(supplier);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public async Task<Supplier> UpdateSupplier(int supplierId, Supplier supplier)
        {
            try
            {
                return await _supplierRepository.UpdateSupplier(supplierId, supplier);
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
    }
}
