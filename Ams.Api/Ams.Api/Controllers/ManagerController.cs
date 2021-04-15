using Ams.Domain.Entities;
using Ams.Persistence.EF.Persistence;
using Ams.Persistence.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ams.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerRepository _managerRepository;

        public ManagerController(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<DepartmentsManagerNumber>> GetAll()
        {
            return await _managerRepository.GetAllDepManNumb();
        }

        [HttpDelete]
        public async Task<DeptManager> DeleteManager(int managerNumber)
        {
            return await _managerRepository.DeleteConcreteManager(managerNumber);
        }

        [HttpPost]
        public async Task<DeptManager> CreateManager(int employeeNumber, string departmentNumber)
        {
            return await _managerRepository.CreateConcreteManager(employeeNumber, departmentNumber);
        }
    }
}
