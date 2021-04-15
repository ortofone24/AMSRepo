using Ams.Domain.Entities;
using Ams.Persistence.EF.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ams.Persistence.EF.Repositories
{
    public class ManagerRepository : BaseRepository<DeptManager>, IManagerRepository
    {
        public ManagerRepository(DB_A47B47_ortofoneContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<DepartmentsManagerNumber>> GetAllDepManNumb()
        {
            return await  _dbContext.DepartmentsManagerNumbers.ToListAsync();
        }

        public async Task<DeptManager> DeleteConcreteManager(int managerNumber)
        {
            var result = await _dbContext.DeptManagers.FirstOrDefaultAsync(e => e.EmpNo == managerNumber);
            if (result != null)
            {
                _dbContext.DeptManagers.Remove(result);
                await _dbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<DeptManager> CreateConcreteManager(int employeeNumber, string departmentNumber)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmpNo == employeeNumber);
            var department = await _dbContext.Departments.FirstOrDefaultAsync(e => e.DeptNo == departmentNumber);

            if (employee != null && department != null)
            {
                var depMan = new DeptManager
                {
                    DeptNo = department.DeptNo,
                    EmpNo = employee.EmpNo,
                    FromDate = DateTime.Now,
                    ToDate = DateTime.Now.AddYears(1)
                };
                _dbContext.DeptManagers.Add(depMan);
                await _dbContext.SaveChangesAsync();
                return depMan;
            }
            return null;
        }
    }
}
