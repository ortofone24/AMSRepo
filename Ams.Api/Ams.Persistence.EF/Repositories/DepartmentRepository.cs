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
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DB_A47B47_ortofoneContext dbContext) : base(dbContext)
        {

        }

        public async Task <IEnumerable<DepartmentsView>> GetDepartmentsView()
        {
            return await _dbContext.DepartmentsViews.ToListAsync();
        }

        public async Task<IEnumerable<Department>> GetDepartament()
        {
            return await _dbContext.Departments.ToListAsync();
        }
    }
}
