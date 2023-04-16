using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.WorkOrders;

namespace MasterData.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrdersController: ControllerBase
    {
      private readonly WorkOrderService _service;

        public WorkOrdersController(WorkOrderService service)
        {
            _service = service;
        }

        // GET: api/WorkOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkOrderDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/WorkOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkOrderDto>> GetGetById(Guid id)
        {
            var cust = await _service.GetByIdAsync(new WorkOrderId(id));

            if (cust == null)
            {
                return NotFound();
            }

            return cust;
        }

        // GET: api/Reports/company
        [HttpGet("workorder/{company}")]
        public async Task<ActionResult<IEnumerable<WorkOrderDto>>> GetWorkOrderByCompanyAsync(string company)
        {
            return await _service.GetWorkOrderByCompanyAsync(company);
        }


        // POST: api/WorkOrders
        [HttpPost]
        public async Task<ActionResult<WorkOrderDto>> Create(WorkOrderDto dto)
        {
            var cust = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = cust.Id }, cust);
        }

        
        // PUT: api/WorkOrders/5
        [HttpPut("{id}")]
        public async Task<ActionResult<WorkOrderDto>> Update(Guid id, WorkOrderDto dto)
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

        // Inactivate: api/WorkOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkOrderDto>> SoftDelete(Guid id)
        {
            var cust = await _service.InactivateAsync(new WorkOrderId(id));

            if (cust == null)
            {
                return NotFound();
            }

            return Ok(cust);
        }
        
        // DELETE: api/WorkOrders/5
        [HttpDelete("hard/{id}")]
        public async Task<ActionResult<WorkOrderDto>> HardDelete(Guid id)
        {
            try
            {
                var cust = await _service.DeleteAsync(new WorkOrderId(id));

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