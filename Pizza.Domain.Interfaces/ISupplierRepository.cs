using Pizza.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<Supplier> UpdateSupplier(int supplierId, Supplier supplier);
    }
}
