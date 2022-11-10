using CRM_Web_API_BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerManager customerManager;
        public CustomersController(ICustomerManager _customerManager)
        {
            customerManager = _customerManager;
        }
        [HttpGet]
        public ActionResult<IEnumerable<CustomerReadDTO>> GetAllCustomers()
        {
            return customerManager.GetAllCustomers();
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<CustomerReadDTO> GetCustomerDyId(int id)
        {
            var Customer = customerManager.GetCustomerById(id);
            if (Customer == null)
            {
                return NotFound();
            }
            return Customer;
        }
        // POST: api/Customers
        [HttpPost]
        public ActionResult<CustomerReadDTO> AddCustomer(CustomerWriteDto Customer)
        {
            var CustomerRead = customerManager.AddCustomer(Customer);
            return CreatedAtAction("GetCustomerDyId", new { id = CustomerRead.Id }, CustomerRead);
        }
        // PUT: api/Customers/5
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult EditCustomer(CustomerWriteDto Customer)
        {
            var result = customerManager.UpdateCustomer(Customer);
            if (!result)
                return NotFound();

            return NoContent();
        }
        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var result = customerManager.DeleteCustomer(id);
            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
