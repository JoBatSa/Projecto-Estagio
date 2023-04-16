using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using System.Threading.Tasks;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.VisualAids;
using Microsoft.AspNetCore.Http;

namespace MasterData.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class VisualAidsController: ControllerBase
    {
        
  private readonly VisualAidService _service;

        public VisualAidsController(VisualAidService service)
        {
            _service = service;
        }

        // GET: api/VisualAids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VisualAidDto>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/VisualAids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VisualAidDto>> GetGetById(Guid id)
        {
            var cust = await _service.GetByIdAsync(new VisualAidId(id));

            if (cust == null)
            {
                return NotFound();
            }

            return cust;
        }


        // GET: api/VisualAids/company
        [HttpGet("visualaid/{company}")]
        public async Task<ActionResult<IEnumerable<VisualAidDto>>> GetVisualAidByCompanyAsync(string company)
        {
            return await _service.GetVisualAidByCompanyAsync(company);
        }

        // POST: api/VisualAids/file
     /*   [HttpPost]
        public async Task<ActionResult<VisualAidDto>> CreateFile(VisualAidDto dto)
        {
             var caminho = await _service.OnPostUploadAsync(dto.ficheiro);

            dto.Picture=caminho;
            var cust = this.Create(dto);
        return CreatedAtAction(nameof(GetGetById), new { id = cust.Id }, cust);
         
        }*/
[HttpPut("File")]
        public async Task<IActionResult> OnPostUploadAsync(IFormFile file)
        {   var filePath ="";

            if (file.Length > 0)
            {
               filePath = "D:/Zecar/Documents/projecto-estagio/MasterDataUI/src/assets/";

                filePath = filePath + file.FileName;
                if (!System.IO.File.Exists(filePath))
                {

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }

 return Ok(  filePath  );

                }
                else
                {
                    return Ok(  ""  );
                }


            }



            return Ok(  filePath  );
        }









        [HttpPost]
        public async Task<ActionResult<VisualAidDto>> Create(VisualAidDto dto)
        {
         
            var cust = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetGetById), new { id = cust.Id }, cust);
        }
        /*
        // PUT: api/VisualAids/5
        [HttpPut("{id}")]
        public async Task<ActionResult<VisualAidDto>> Update(Guid id, VisualAidDto dto)
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
*/
        // Inactivate: api/VisualAids/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VisualAidDto>> SoftDelete(Guid id)
        {
            var cust = await _service.InactivateAsync(new VisualAidId(id));

            if (cust == null)
            {
                return NotFound();
            }

            return Ok(cust);
        }
        
        // DELETE: api/VisualAids/5
        [HttpDelete("hard/{id}")]
        public async Task<ActionResult<VisualAidDto>> HardDelete(Guid id)
        {
            try
            {
                var cust = await _service.DeleteAsync(new VisualAidId(id));

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