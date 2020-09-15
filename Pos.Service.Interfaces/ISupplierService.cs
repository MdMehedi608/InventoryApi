using Pizza.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Interfaces
{
    public interface ISupplierService
    {
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<Supplier> UpdateSupplier(int supplierId, Supplier supplier);
    }
}
