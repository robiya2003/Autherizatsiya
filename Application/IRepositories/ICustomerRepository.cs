using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public  interface ICustomerRepository
    {
        public CustomerModel CreateCustomer(CustomerModel customerModel);
        public CustomerModel UpdateCustomer(CustomerLogIn customerLogIn,CustomerModel customerModel);
        public CustomerModel GetByUserNameAndPassword(CustomerLogIn customerLogIn);
        public CustomerModel DeleteUserNameAndPassword(CustomerLogIn customerLogIn);
        public CustomerLogIn EnterUser(CustomerLogIn customerLogIn);
    }
}
