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
    [Route("api/product")]    
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<controller>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addproduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            try
            {
                var data = await _productService.AddProduct(product);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@product} on {AddProduct}", product, DateTime.Now);
                throw exception;
            }
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addproduct/{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] Product product)
        {
            try
            {
                var data = await _productService.UpdateProduct(productId, product);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@product} on {UpdateProduct}", product, DateTime.Now);
                throw exception;
            }
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactiveproduct")]
        public async Task<IActionResult> GetAllActiveProduct()
        {
            try
            {
                var data = await _productService.GetAllActiveProduct();
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {GetAllActiveProduct}", DateTime.Now);
                throw exception;
            }
        }

    }
}
