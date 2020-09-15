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
    [Route("api/category")]
    public class CategoryController : Controller
    {
        // GET: api/<controller>
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addcategory")]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            try
            {
                var data = await _categoryService.AddCategory(category);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@category} on {AddCategory}", category, DateTime.Now);
                throw exception;
            }
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("updatecategory/{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, [FromBody] Category category)
        {
            try
            {
                var data = await _categoryService.UpdateCategory(categoryId, category);
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {@category} on {UpdateCategory}", category, DateTime.Now);
                throw exception;
            }
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactivecategory")]
        public async Task<IActionResult> GetAllActiveCategory()
        {
            try
            {
                var data = await _categoryService.GetAllActiveCategory();
                return Ok(data);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "Error report generate {GetAllActiveUnit}", DateTime.Now);
                throw exception;
            }
        }

    }
}
