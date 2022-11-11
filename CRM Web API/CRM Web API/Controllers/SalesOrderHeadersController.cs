using CRM_Web_API_BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderHeadersController : ControllerBase
    {
        private readonly ISalseOrderHeaderManager SalesOrderHeaderManager;
        public SalesOrderHeadersController(ISalseOrderHeaderManager _SalesOrderHeaderManager)
        {
            SalesOrderHeaderManager = _SalesOrderHeaderManager;
        }
        [HttpGet]
        public ActionResult<IEnumerable<SalseOrderHeaderReadDTO>> GetAllSalesOrderHeaders()
        {
            return SalesOrderHeaderManager.GetAllSalseOrderHeaders();
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<SalseOrderHeaderReadDTO> GetSalesOrderHeaderDyId(int id)
        {
            var SalesOrderHeader = SalesOrderHeaderManager.GetSalseOrderHeaderById(id);
            if (SalesOrderHeader == null)
            {
                return NotFound();
            }
            return SalesOrderHeader;
        }
        // POST: api/SalesOrderHeaders
        [HttpPost]
        public ActionResult<SalseOrderHeaderReadDTO> AddSalesOrderHeader(SalseOrderHeaderWriteDTO SalesOrderHeader)
        {
            var SalesOrderHeaderRead = SalesOrderHeaderManager.AddSalseOrderHeader(SalesOrderHeader);
            return CreatedAtAction("GetAllSalesOrderHeaders", new { id = SalesOrderHeaderRead.Id }, SalesOrderHeaderRead);
        }
        // PUT: api/SalesOrderHeaders/5
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult EditSalesOrderHeader(SalseOrderHeaderWriteDTO SalesOrderHeader)
        {
            var result = SalesOrderHeaderManager.UpdateSalseOrderHeader(SalesOrderHeader);
            if (!result)
                return NotFound();

            return NoContent();
        }
        // DELETE: api/SalesOrderHeaders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSalesOrderHeader(int id)
        {
            var result = SalesOrderHeaderManager.DeleteSalseOrderHeader(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
