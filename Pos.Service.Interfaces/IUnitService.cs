using Pizza.Domain.Entities.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Service.Interfaces
{
    public interface IUnitService
    {
        Task<Unit> AddUnit(Unit unit);
        Task<IEnumerable<Unit>> GetAllActiveUnit();
        Task<Unit> UpdateUnit(int unitId, Unit unit);
    }
}
