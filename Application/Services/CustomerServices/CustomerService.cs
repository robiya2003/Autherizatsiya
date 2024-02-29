using Application.IRepositories;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
             _customerRepository = customerRepository;
        }
        public CustomerModel CreateCustomer(CustomerModel customerModel)
        {
            return _customerRepository.CreateCustomer(customerModel);
        }

        public CustomerModel DeleteUserNameAndPassword(CustomerLogIn customerLogIn)
        {
            return _customerRepository.DeleteUserNameAndPassword(customerLogIn);
        }

        public CustomerLogIn EnterUser(CustomerLogIn customerLogIn)
        {
            return _customerRepository.EnterUser(customerLogIn);
        }

        public CustomerModel GetByUserNameAndPassword(CustomerLogIn customerLogIn)
        {
            return _customerRepository.GetByUserNameAndPassword(customerLogIn);
        }

        public CustomerModel UpdateCustomer(string username, string password, CustomerModel customerModel)
        {
            return _customerRepository.UpdateCustomer(username,password, customerModel);
        }
    }
}
