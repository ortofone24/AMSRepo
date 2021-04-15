using Ams.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ams.Persistence.EF.Persistence
{
    public interface IManagerRepository : IAsyncRepository<DeptManager>
    {
        Task<IEnumerable<DepartmentsManagerNumber>> GetAllDepManNumb();
        Task<DeptManager> DeleteConcreteManager(int managerNumber);
        Task<DeptManager> CreateConcreteManager(int employeeNumber, string departmentNumber);
    }
}
