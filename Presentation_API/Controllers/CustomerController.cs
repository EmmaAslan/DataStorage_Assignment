using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;

        #region Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            var customers = await _customerService.GetAllAsync();
            if (customers is null)
                return BadRequest("No customers was found");

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomer(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer is null)
                return BadRequest("No customer was found with this Id.");

            return Ok(customer);
        }

        //Använde ChatGPT 4o för att få hjälp på ett ungefär hur man skapar en Post.
        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody] CustomerRegistrationForm form)
        {
            if (form is null)
                return BadRequest("Customer model is null");

            await _customerService.CreateAsync(form);

            return Ok();
        }

        //Använde ChatGPT 4o för att få hjälp hur man strukturerar en Put.
        [HttpPut]
        public async Task<ActionResult<CustomerModel>> UpdateCustomer([FromBody] CustomerModel customer)
        {
            if (customer == null)
                return BadRequest("Invalid data");

            var updatedCustomer = await _customerService.UpdateAsync(customer);

            if (updatedCustomer is null)
                return BadRequest("Customer was not updated");

            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerModel>> DeleteCustomer(int id)
        {
            var customer = await _customerService.DeleteAsync(id);

            if (customer is false)
                return BadRequest("Customer was not deleted.");

            return Ok(customer);
        }

        #endregion
    }
}
