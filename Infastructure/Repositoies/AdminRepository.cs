using Application.IRepositories;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositoies
{
    public class AdminRepository : IAdminRepository
    {
        public AdminModel CreateAdmin(AdminModel adminModel)
        {
            throw new NotImplementedException();
        }

        public AdminModel DeleteAdminNameAndPassword(AdminLogIn adminLogIn)
        {
            throw new NotImplementedException();
        }

        public AdminLogIn EnterAdmin(AdminLogIn adminLogIn)
        {
            throw new NotImplementedException();
        }

        public AdminModel GetByAdminNameAndPassword(AdminLogIn adminLogIn)
        {
            throw new NotImplementedException();
        }

        public AdminModel UpdateAdmin(AdminLogIn adminLogIn, CustomerModel adminModel)
        {
            throw new NotImplementedException();
        }
    }
}
