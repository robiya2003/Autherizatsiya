using Application.IRepositories;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositoies
{
    public class CustomerRepository : ICustomerRepository
    {
        public CustomerModel CreateCustomer(CustomerModel customerModel)
        {
            throw new NotImplementedException();
        }

        public CustomerModel DeleteUserNameAndPassword(CustomerLogIn customerLogIn)
        {
            throw new NotImplementedException();
        }

        public CustomerLogIn EnterUser(CustomerLogIn customerLogIn)
        {
            throw new NotImplementedException();
        }

        public CustomerModel GetByUserNameAndPassword(CustomerLogIn customerLogIn)
        {
            throw new NotImplementedException();
        }

        public CustomerModel UpdateCustomer(CustomerLogIn customerLogIn, CustomerModel customerModel)
        {
            throw new NotImplementedException();
        }
    }
}
