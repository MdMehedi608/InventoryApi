using Pizza.Domain.Entities.DataModel;
using Pizza.Domain.Interfaces;
using Pos.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service
{
    public class UnitService:IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        public UnitService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }
        public async Task<Unit> AddUnit(Unit unit)
        {
            try
            {
                return await _unitRepository.AddUnit(unit);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<Unit> UpdateUnit(int unitId, Unit unit)
        {
            try
            {
                return await _unitRepository.UpdateUnit(unitId, unit);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<IEnumerable<Unit>> GetAllActiveUnit()
        {
            try
            {
                return await _unitRepository.GetAllActiveUnit();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
