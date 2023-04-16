
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.WorkAuthorizations;


namespace MasterData.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class WorkAuthorizationsController: ControllerBase
    {
     private readonly WorkAuthorizationService _service;

        public WorkAuthorizationsController(WorkAuthorizationService service)
        {
            _service = service;
        }

        // GET: api/WorkAuthorizations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkAuthorizationDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/WorkAuthorizations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkAuthorizationDto>> GetGetById(Guid id)
        {
            var cust = await _service.GetByIdAsync(new WorkAuthorizationId(id));

            if (cust == null)
            {
                return NotFound();
            }

            return cust;
        }


        // GET: api/WorkAuthorization/company
        [HttpGet("workAuthorization/{company}")]
        public async Task<ActionResult<IEnumerable<WorkAuthorizationDto>>> GetWorkAuthorizationByCompanyAsync(string company)
        {
            return await _service.GetWorkAuthorizationByCompanyAsync(company);
        }




        // POST: api/WorkAuthorizations
        [HttpPost]
        public async Task<ActionResult<WorkAuthorizationDto>> Create(WorkAuthorizationDto dto)
        {
            var cust = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = cust.Id }, cust);
        }

     
        // PUT: api/WorkAuthorizations/5
        [HttpPut("{id}")]
        public async Task<ActionResult<WorkAuthorizationDto>> Update(Guid id, WorkAuthorizationDto dto)
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

        // Inactivate: api/WorkAuthorizations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WorkAuthorizationDto>> SoftDelete(Guid id)
        {
            var cust = await _service.InactivateAsync(new WorkAuthorizationId(id));

            if (cust == null)
            {
                return NotFound();
            }

            return Ok(cust);
        }
        
        // DELETE: api/WorkAuthorizations/5
        [HttpDelete("hard/{id}")]
        public async Task<ActionResult<WorkAuthorizationDto>> HardDelete(Guid id)
        {
            try
            {
                var cust = await _service.DeleteAsync(new WorkAuthorizationId(id));

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