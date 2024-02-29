using Application.Services.CustomerServices;
using Domains.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public IActionResult CreateCustomer(CustomerModel customerModel)
        {
            return Ok(_customerService.CreateCustomer(customerModel));
        }
        [HttpDelete]
        public IActionResult DeleteCustomer(CustomerLogIn customerLogIn)
        {
            return Ok(_customerService.DeleteUserNameAndPassword(customerLogIn));
        }
        [HttpGet]
        public IActionResult GetCustomers(CustomerLogIn customerLogIn)
        {
            return Ok(_customerService.EnterUser(customerLogIn));
        }
        [HttpGet]
        public IActionResult GetUsernameByPasword(CustomerLogIn customer)
        {
            return Ok(_customerService.GetByUserNameAndPassword(customer));

        }
        [HttpPut]
        public IActionResult PutCustomer(string username, string password,CustomerModel customerModel)
        {
            return Ok(_customerService.UpdateCustomer(username, password, customerModel));              
        }
    }
}
