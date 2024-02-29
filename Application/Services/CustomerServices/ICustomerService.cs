using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerServices
{
    public interface ICustomerService
    {
        public CustomerModel CreateCustomer(CustomerModel customerModel);
        public CustomerModel UpdateCustomer(string username, string password, CustomerModel customerModel);
        public CustomerModel GetByUserNameAndPassword(CustomerLogIn customerLogIn);
        public CustomerModel DeleteUserNameAndPassword(CustomerLogIn customerLogIn);
        public CustomerLogIn EnterUser(CustomerLogIn customerLogIn);
    }
}
