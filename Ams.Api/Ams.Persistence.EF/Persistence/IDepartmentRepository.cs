using Ams.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams.Persistence.EF.Persistence
{
    public interface IDepartmentRepository : IAsyncRepository<Department>
    {
        Task<IEnumerable<DepartmentsView>> GetDepartmentsView();
        Task<IEnumerable<Department>> GetDepartament();
    }
}
