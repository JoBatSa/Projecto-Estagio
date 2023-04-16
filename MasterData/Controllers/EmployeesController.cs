using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Threading.Tasks;
using DDDSample1.Domain.Shared;


using DDDSample1.Domain.Employees;



namespace MasterData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _service;

        public EmployeesController(EmployeeService service)
        {
            _service = service;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetGetById(Guid id)
        {
            var emp = await _service.GetByIdAsync(new EmployeeId(id));

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }

        // GET: api/Employees/name
        [HttpGet("name/{name}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetByName(string name)
        {
            

            return await _service.GetByNameAsync(name);
        }


        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> Create(EmployeeDto dto)
        {
            var emp = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = emp.Id }, emp);
        }

       
        //(Change job position) PUT: api/Employees/Id
        [HttpPut("{id}")]
        public async Task<ActionResult<EmployeeDto>> Update(Guid id, EmployeeDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            try
            {
                var emp = await _service.UpdateAsync(dto);
                
                if (emp == null)
                {
                    return NotFound();
                }
                return Ok(emp);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

        // Soft delete, Deactivate: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeDto>> SoftDelete(Guid id)
        {
            var emp = await _service.InactivateAsync(new EmployeeId(id));

            if (emp == null)
            {
                return NotFound();
            }

            return Ok(emp);
        }
        
        // DELETE: api/Employees/5
        [HttpDelete("hard/{id}")]
        public async Task<ActionResult<EmployeeDto>> HardDelete(Guid id)
        {
            try
            {
                var emp = await _service.DeleteAsync(new EmployeeId(id));

                if (emp == null)
                {
                    return NotFound();
                }

                return Ok(emp);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}