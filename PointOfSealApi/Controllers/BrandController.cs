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
    [Route("api/brand")]
    public class BrandController : Controller
    {
        // GET: api/<controller>
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addbrand")]
        public async Task<IActionResult> AddBrand([FromBody] Brand brand)
        {
            try
            {
                var data = await _brandService.AddBrand(brand);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@brand} on {AddBrand}", brand, DateTime.Now);
                throw exception;
            }
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("updatebrand/{brandId}")]
        public async Task<IActionResult> UpdateBrand(int brandId, [FromBody] Brand brand)
        {
            try
            {
                var data = await _brandService.UpdateBrand(brandId, brand);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@brand} on {UpdateBrand}", brand, DateTime.Now);
                throw exception;
            }
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactivebrand")]
        public async Task<IActionResult> GetAllActiveBrand()
        {
            try
            {
                var data = await _brandService.GetAllActiveBrand();
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {GetAllAtiveBrand}", DateTime.Now);
                throw exception;
            }
        }
    }
}
