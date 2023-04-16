using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Threading.Tasks;
using DDDSample1.Domain.Shared;


using DDDSample1.Domain.Customers;

namespace DDDSample1.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _service;

        public CustomersController(CustomerService service)
        {
            _service = service;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetById(Guid id)
        {
            var cust = await _service.GetByIdAsync(new CustomerId(id));

            if (cust == null)
            {
                return NotFound();
            }

            return cust;
        }
        // GET: api/Customers/company
        [HttpGet("company/{company}")]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetByCompany(string company)
        {
            var cust = await _service.GetByCompanyAsync((company));

          //  if (cust == null)
          //  {
          //      return NotFound();
         //   }

            return await _service.GetByCompanyAsync(company);
        }


        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<CustomerDto>> Create(CustomerDto dto)
        {
            var cust = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = cust.Id }, cust);
        }

        
        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerDto>> Update(Guid id, CustomerDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            try
            {
                var cust = await _service.UpdateAsync(dto);
                
                if (cust == null)
                {
                    return NotFound();
                }
                return Ok(cust);
            }
            catch(BusinessRuleValidationException ex)
            {
                return BadRequest(new {Message = ex.Message});
            }
        }

        // Inactivate: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerDto>> SoftDelete(Guid id)
        {
            var cust = await _service.InactivateAsync(new CustomerId(id));

            if (cust == null)
            {
                return NotFound();
            }

            return Ok(cust);
        }
        
        // DELETE: api/Customers/5
        [HttpDelete("hard/{id}")]
        public async Task<ActionResult<CustomerDto>> HardDelete(Guid id)
        {
            try
            {
                var cust = await _service.DeleteAsync(new CustomerId(id));

                if (cust == null)
                {
                    return NotFound();
                }

                return Ok(cust);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}