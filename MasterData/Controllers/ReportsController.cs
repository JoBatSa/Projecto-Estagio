using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Threading.Tasks;

using DDDSample1.Domain.Reports;

namespace MasterData.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController: ControllerBase
    {
          private readonly ReportService _service;

        public ReportsController(ReportService service)
        {
            _service = service;
        }

        // GET: api/Reports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Reports/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportDto>> GetGetById(Guid id)
        {
            var emp = await _service.GetByIdAsync(new ReportId(id));

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }

        // GET: api/Reports/Employeename
        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetReportByName(string name)
        {
            return await _service.GetReportByNameAsync(name);
        }

         // GET: api/Reports/company
        [HttpGet("company/{company}")]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetReportByComany(string company)
        {
            return await _service.GetReportByCompanyAsync(company);
        }

        // POST: api/Reports
        [HttpPost]
        public async Task<ActionResult<ReportDto>> Create(ReportDto dto)
        {
            var emp = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = emp.Id }, emp);
        }


        // DELETE: api/Reports/5
        [HttpDelete("hard/{id}")]
        public async Task<ActionResult<ReportDto>> HardDelete(Guid id)
        {
           
                var cust = await _service.DeleteAsync(new ReportId(id));

                if (cust == null)
                {
                    return NotFound();
                }

                return Ok(cust);
            
        }

    }
}