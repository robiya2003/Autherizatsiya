using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AdminServices
{
    public interface IAdminService
    {
        public AdminModel CreateAdmin(AdminModel adminModel);
        public AdminModel UpdateAdmin(AdminLogIn adminLogIn, CustomerModel adminModel);
        public AdminModel GetByAdminNameAndPassword(AdminLogIn adminLogIn);
        public AdminModel DeleteAdminNameAndPassword(AdminLogIn adminLogIn);
        public AdminLogIn EnterAdmin(AdminLogIn adminLogIn);
    }
}
