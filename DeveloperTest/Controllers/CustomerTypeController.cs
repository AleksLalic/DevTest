using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerTypeController : ControllerBase
    {
        private static readonly string[] CustomerTypes = { "Large", "Small"};

        private readonly ILogger<CustomerTypeController> _logger;

        public CustomerTypeController(ILogger<CustomerTypeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return CustomerTypes;
        }
    }
}
