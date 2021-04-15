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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [Route("getManagers")]
        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<DepartmentsView>> Get()
        {
            return await _departmentRepository.GetDepartmentsView();
        }

        [Route("getDepartments")]
        [HttpGet]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Department>> GetDepartament()
        {
            return await _departmentRepository.GetDepartament();
        }
    }
}
