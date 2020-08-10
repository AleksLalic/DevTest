using System;
using Microsoft.AspNetCore.Mvc;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customerService.GetCustomers());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var job = customerService.GetCustomer(id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        [HttpPost]
        public IActionResult Create(BaseCustomerModel model)
        {
            if (model.Name.Length < 5)
            {
                return BadRequest("Name must be at least 5 charatcers long");
            }

            var customer = customerService.CreateCustomer(model);

            return Created($"customer/{customer.CustomerId}", customer);
        }
    }
}
