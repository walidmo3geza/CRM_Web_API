using CRM_Web_API_BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressesController : ControllerBase
    {
        private readonly ICustomerAddressManager CustomerAddressManager;
        public CustomerAddressesController(ICustomerAddressManager _CustomerAddressManager)
        {
            CustomerAddressManager = _CustomerAddressManager;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CustomerAddressReadDTO>> GetAllCustomerAddresss()
        {
            return CustomerAddressManager.GetAllCustomerAddresss();
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<CustomerAddressReadDTO> GetCustomerAddressDyId(int id)
        {
            var CustomerAddress = CustomerAddressManager.GetCustomerAddressById(id);
            if (CustomerAddress == null)
            {
                return NotFound();
            }
            return CustomerAddress;
        }
        // POST: api/CustomerAddresss
        [HttpPost]
        public ActionResult<CustomerAddressReadDTO> AddCustomerAddress(CustomerAddressWriteDTO CustomerAddress)
        {
            var CustomerAddressRead = CustomerAddressManager.AddCustomerAddress(CustomerAddress);
            return CreatedAtAction("GetCustomerAddressDyId", new { id = CustomerAddressRead.Id }, CustomerAddressRead);
        }
        // PUT: api/CustomerAddresss/5
        [HttpPut]
        public IActionResult EditCustomerAddress(CustomerAddressWriteDTO CustomerAddress)
        {
            var result = CustomerAddressManager.UpdateCustomerAddress(CustomerAddress);
            if (!result)
                return NotFound();

            return NoContent();
        }
        // DELETE: api/CustomerAddresss/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomerAddress(int id)
        {
            var result = CustomerAddressManager.DeleteCustomerAddress(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
