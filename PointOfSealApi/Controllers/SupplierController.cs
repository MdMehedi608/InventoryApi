using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizza.Domain.Entities.DataModel;
using Pos.Service.Interfaces;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PointOfSealApi.Controllers
{
    [Route("api/supplier")]
    public class SupplierController : Controller
    {
        // GET: api/<controller>

        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addsupplier")]
        public async Task<IActionResult> AddSupplier([FromBody] Supplier supplier)
        {
            try
            {
                var data = await _supplierService.AddSupplier(supplier);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@supplier} on {AddSupplier}", supplier, DateTime.Now);
                throw exception;
            }
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("updatesupplier/{supplierId}")]
        public async Task<IActionResult> UpdateSupplier(int supplierId, [FromBody] Supplier supplier)
        {
            try
            {
                var data = await _supplierService.UpdateSupplier(supplierId, supplier);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@supplier} on {UpdateSupplier}", supplier, DateTime.Now);
                throw exception;
            }
        }
    }
}
