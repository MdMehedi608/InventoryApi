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
    [Route("api/unit")]
    public class UnitController : Controller
    {
        // GET: api/<controller>
        private readonly IUnitService _unitService;
        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("addunit")]
        public async Task<IActionResult> AddUnit([FromBody] Unit unit)
        {
            try
            {
                var data = await _unitService.AddUnit(unit);
                return Ok(data);
            }
            catch(Exception exception)
            {
                Log.Error(exception, "Error report generate {@unit} on {AddUnit}", unit, DateTime.Now);
                throw exception;
            }
        } 
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("updateunit/{unitId}")]
        public async Task<IActionResult> UpdateUnit(int unitId, [FromBody] Unit unit)
        {
            try
            {
                var data = await _unitService.UpdateUnit(unitId, unit);
                return Ok(data);
            }
            catch(Exception exception)
            {
                Log.Error(exception, "Error report generate {@unit} on {UpdateUnit}", unit, DateTime.Now);
                throw exception;
            }
        } 
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Route("getallactiveunit")]
        public async Task<IActionResult> GetAllActiveUnit()
        {
            try
            {
                var data = await _unitService.GetAllActiveUnit();
                return Ok(data);
            }
            catch(Exception exception)
            {
                Log.Error(exception, "Error report generate {GetAllActiveUnit}", DateTime.Now);
                throw exception;
            }
        } 
    }
}
