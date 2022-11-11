using CRM_Web_API_BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesOrderDetailsController : ControllerBase
    {
        private readonly ISalesOrderDetailManager SalesOrderDetailsManager;
        public SalesOrderDetailsController(ISalesOrderDetailManager _SalesOrderDetailsManager)
        {
            SalesOrderDetailsManager = _SalesOrderDetailsManager;
        }
        [HttpGet]
        public ActionResult<IEnumerable<SalesOrderDetailsReadDTO>> GetAllSalesOrderDetailss()
        {
            return SalesOrderDetailsManager.GetAllSalseOrderDetails();
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<SalesOrderDetailsReadDTO> GetSalesOrderDetailsDyId(int id)
        {
            var SalesOrderDetails = SalesOrderDetailsManager.GetSalseOrderDetailsById(id);
            if (SalesOrderDetails == null)
            {
                return NotFound();
            }
            return SalesOrderDetails;
        }
        // POST: api/SalesOrderDetailss
        [HttpPost]
        public ActionResult<SalesOrderDetailsReadDTO> AddSalesOrderDetails(SalesOrderDetailsWriteDTO SalesOrderDetails)
        {
            var SalesOrderDetailsRead = SalesOrderDetailsManager.AddSalseOrderDetails(SalesOrderDetails);
            return CreatedAtAction("GetSalesOrderDetailsDyId", new { id = SalesOrderDetailsRead.Id }, SalesOrderDetailsRead);
        }
        // PUT: api/SalesOrderDetailss/5
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult EditSalesOrderDetails(SalesOrderDetailsWriteDTO SalesOrderDetails)
        {
            var result = SalesOrderDetailsManager.UpdateSalseOrderDetails(SalesOrderDetails);
            if (!result)
                return NotFound();

            return NoContent();
        }
        // DELETE: api/SalesOrderDetailss/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSalesOrderDetails(int id)
        {
            var result = SalesOrderDetailsManager.DeleteSalseOrderDetails(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
