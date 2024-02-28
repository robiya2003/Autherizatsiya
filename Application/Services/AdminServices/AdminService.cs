using Application.IRepositories;
using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        public AdminModel CreateAdmin(AdminModel adminModel)
        {
            return _adminRepository.CreateAdmin(adminModel);
        }

        public AdminModel DeleteAdminNameAndPassword(AdminLogIn adminLogIn)
        {
            return _adminRepository.DeleteAdminNameAndPassword(adminLogIn);
        }

        public AdminLogIn EnterAdmin(AdminLogIn adminLogIn)
        {
            return _adminRepository.EnterAdmin(adminLogIn);
        }

        public AdminModel GetByAdminNameAndPassword(AdminLogIn adminLogIn)
        {
            return _adminRepository.GetByAdminNameAndPassword(adminLogIn);
        }

        public AdminModel UpdateAdmin(AdminLogIn adminLogIn, CustomerModel adminModel)
        {
            return _adminRepository.UpdateAdmin(adminLogIn, adminModel);
        }
    }
}
