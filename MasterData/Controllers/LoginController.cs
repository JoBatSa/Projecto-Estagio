using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Employees;

using DDDSample1.Domain.Logins;

namespace DDDSample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _service;

        public LoginController(LoginService service)
        {
            _service = service;
        }



        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginDto>> GetGetById(Guid id)
        {
            var log = await _service.GetByIdAsync(new LoginId(id));

            if (log == null)
            {
                return NotFound();
            }

            return log;
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<LoginDto>> Create(CreateLoginDto dto)
        {
           
            var log = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = log.Id }, log);
        }

          
        // DELETE: api/Categories/5
        [HttpDelete("hard/{id}")]
        public async Task<ActionResult<LoginDto>> HardDelete(Guid id)
        {
            try
            {
                var log = await _service.DeleteAsync(new LoginId(id));

                if (log == null)
                {
                    return NotFound();
                }

                return Ok(log);
            }
            catch(BusinessRuleValidationException ex)
            {
               return BadRequest(new {Message = ex.Message});
            }
        }
    }
}