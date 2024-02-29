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
        public CustomerModel CreateCustomer(CustomerModel customerModel)
        {
            return _customerService.CreateCustomer(customerModel);
        }
        [HttpDelete]
        public CustomerModel DeleteCustomer(string username, string password)
        {
            
            return _customerService.DeleteUserNameAndPassword(new CustomerLogIn(){Username = username,Password = password});
        }
        [HttpGet]
        public CustomerLogIn GetCustomers(string username, string password)
        {
            return _customerService.EnterUser(new CustomerLogIn() { Username = username, Password = password });
        }
        [HttpGet]
        public CustomerModel GetUsernameByPasword(string username, string password)
        {
            return _customerService.GetByUserNameAndPassword(new CustomerLogIn() { Username = username, Password = password });

        }
        [HttpPut]
        public CustomerModel PutCustomer(string username, string password,CustomerModel customerModel)
        {
            return _customerService.UpdateCustomer(username, password, customerModel);              
        }
    }
}
