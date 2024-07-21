using Heetapp1.Interfaces;
using Heetapp1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace Heetapp1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NoContent();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _customerService.AddCustomer(customer);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customerDto)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            _mapper.Map(customerDto, customer);
            await _customerService.UpdateCustomer(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _customerService.DeleteCustomer(id);
            return NoContent();
        }
    }
}
