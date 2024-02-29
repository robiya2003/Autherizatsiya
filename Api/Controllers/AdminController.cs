using Application.Services.AdminServices;
using Domains.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost]
        public AdminModel PostAdmin(AdminModel adminModel)
        {
            return _adminService.CreateAdmin(adminModel);
        }
        [HttpDelete]
        public AdminModel DeleteAdmin(string username, string password)
        {
            AdminLogIn adminLogIn = new AdminLogIn()
            {
                Adminname = username,
                Password = password
            };
            return _adminService.DeleteAdminNameAndPassword(adminLogIn);
        }
        [HttpGet]
        public AdminLogIn GetAdmin(string username, string password)
        {
            AdminLogIn adminLogIn = new AdminLogIn()
            {
                Adminname = username,
                Password = password
            };
            return _adminService.EnterAdmin(adminLogIn);
        }
        
        [HttpGet]
        public AdminModel GetByAdminNameAndPassword(string username, string password)
        {
            AdminLogIn adminLogIn = new AdminLogIn()
            {
                Adminname = username,
                Password = password
            };
            return _adminService.GetByAdminNameAndPassword(adminLogIn);
        }

        [HttpPut]
        public AdminModel PutAdmin(string username, string password, AdminModel adminModel)
        {
            return _adminService.UpdateAdmin(username,password, adminModel);
        }
    }
}
