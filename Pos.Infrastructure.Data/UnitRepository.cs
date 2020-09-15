using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entities.DataModel;
using Pizza.Domain.Interfaces;
using Pos.Context.EfConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Infrastructure.Data
{
    public class UnitRepository:IUnitRepository
    {
        private readonly SqlServerContext _sqlServerContext;
        public UnitRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext ?? throw new ArgumentNullException(nameof(sqlServerContext));
        }
        public async Task<Unit> AddUnit(Unit unit)
        {
            using(var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    var entity = await _sqlServerContext.Units.FirstOrDefaultAsync(item => item.UnitName == unit.UnitName);
                    if (entity == null)
                    {
                        await _sqlServerContext.Units.AddRangeAsync(unit);
                        await _sqlServerContext.SaveChangesAsync();
                    }
                    else
                    {
                        unit.UnitId = 0;
                        unit.UnitName = "";
                        unit.IsActive = false;
                        unit.CreatedDate = DateTime.Now;
                        unit.CreatedBy = 0;
                        unit.UpdatedBy = 0;
                        unit.UpdatedDate = DateTime.Now;
                    }
                    transaction.Commit();
                    return unit;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }
        }
        public async Task<Unit> UpdateUnit(int unitId, Unit unit)
        {
            using(var transaction = _sqlServerContext.Database.BeginTransaction())
            {
                try
                {
                    var entity = await _sqlServerContext.Units.FirstOrDefaultAsync(item => item.UnitId == unitId);
                    if (entity != null)
                    {
                        entity.UnitName = unit.UnitName;
                        entity.IsActive = unit.IsActive;
                        entity.CreatedBy = unit.CreatedBy;
                        entity.CreatedDate = unit.CreatedDate;
                        entity.UpdatedBy = unit.UpdatedBy;
                        entity.UpdatedDate = unit.UpdatedDate;
                        _sqlServerContext.Units.Update(entity);
                        await _sqlServerContext.SaveChangesAsync();
                    }
                    else
                    {
                        entity.UnitId = 0;
                        entity.UnitName = "";
                        entity.IsActive = false;
                        entity.CreatedDate = DateTime.Now;
                        entity.CreatedBy = 0;
                        entity.UpdatedBy = 0;
                        entity.UpdatedDate = DateTime.Now;
                    }
                    transaction.Commit();
                    return entity;
                }
                catch (Exception exception)
                {
                    transaction.Rollback();
                    throw exception;
                }
            }
        }
        public async Task<IEnumerable<Unit>> GetAllActiveUnit()
        {
            try
            {
                IQueryable<Unit> unitList = (from s in _sqlServerContext.Units
                                             where s.IsActive == true
                                             select new Unit
                                             {
                                                 UnitId = s.UnitId,
                                                 UnitName = s.UnitName,
                                                 IsActive = s.IsActive,
                                                 CreatedDate = s.CreatedDate,
                                                 CreatedBy = s.CreatedBy,
                                                 UpdatedBy = s.UpdatedBy,
                                                 UpdatedDate = s.UpdatedDate
                                             });
                return await unitList.ToListAsync();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
