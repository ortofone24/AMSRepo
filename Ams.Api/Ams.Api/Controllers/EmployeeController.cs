using Ams.Api.Filter;
using Ams.Api.Services;
using Ams.Api.Wrappers;
using Ams.Domain.Entities;
using Ams.Persistence.EF;
using Ams.Persistence.EF.Persistence;
using Ams.Persistence.EF.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ams.Api.Helpers;

namespace Ams.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IUriService uriService;
        private readonly DB_A47B47_ortofoneContext dbContext;

        public EmployeeController(IUriService uriService, DB_A47B47_ortofoneContext dbContext)
        {
            this.uriService = uriService;
            this.dbContext = dbContext;
        }

        [HttpGet("{employeeNumber}")]
        public async Task<IActionResult> GetById(int employeeNumber)
        {
            var employee = await dbContext.EmployeesViews.Where(a => a.EmpNo == employeeNumber).FirstOrDefaultAsync();
            return Ok(new Response<EmployeesView>(employee));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await dbContext.EmployeesViews
                                    .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                    .Take(validFilter.PageSize)
                                    .ToListAsync();
            var totalRecords = await dbContext.EmployeesViews.CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse<EmployeesView>(pagedData, validFilter, totalRecords, uriService, route);
            return Ok(pagedReponse);
        }
    }
}
