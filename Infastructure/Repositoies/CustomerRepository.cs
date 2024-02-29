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
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public CustomerModel CreateCustomer(CustomerModel customerModel)
        {
            var entiry=_context.customers.Add(customerModel);
            _context.SaveChanges();
            return entiry.Entity;
        }

        public CustomerModel DeleteUserNameAndPassword(CustomerLogIn customerLogIn)
        {
            var entiry = _context.customers.
                FirstOrDefault(x => x.Username==customerLogIn.Username && x.Password==customerLogIn.Password);
            var entiry1=_context.Remove(entiry);
            _context.SaveChanges();
            return entiry1.Entity;
        }

        public CustomerLogIn EnterUser(CustomerLogIn customerLogIn)
        {
            var entiry = _context.customers
                .FirstOrDefault(x => x.Username == customerLogIn.Username && x.Password == customerLogIn.Password);
            return customerLogIn;
        }

        public CustomerModel GetByUserNameAndPassword(CustomerLogIn customerLogIn)
        {
            return  _context.customers
                .FirstOrDefault(x => x.Username == customerLogIn.Username && x.Password == customerLogIn.Password);
        }

        public CustomerModel UpdateCustomer(string username, string password, CustomerModel customerModel)
        {
            var entiry = _context.customers
                .FirstOrDefault(x => x.Username == username && x.Password == password);
            entiry.Id= customerModel.Id;
            entiry.FullName= customerModel.FullName;
            entiry.PhoneNumber= customerModel.PhoneNumber;
            entiry.Gmail= customerModel.Gmail;
            entiry.Address= customerModel.Address;
            entiry.Username= customerModel.Username;
            entiry.Password= customerModel.Password;
           _context.SaveChanges();
            return entiry;
        }
    }
}
