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
        public IActionResult PostAdmin(AdminModel adminModel)
        {
            return Ok(_adminService.CreateAdmin(adminModel));
        }
        [HttpDelete]
        public IActionResult DeleteAdmin(AdminLogIn adminLogIn)
        {
            return Ok(_adminService.DeleteAdminNameAndPassword(adminLogIn));
        }
        [HttpGet]
        public IActionResult GetAdmin(AdminLogIn adminLogIn)
        {
            return Ok(_adminService.EnterAdmin(adminLogIn));
        }
        
        [HttpGet]
        public IActionResult GetByAdminNameAndPassword(AdminLogIn adminLogIn)
        {
            return Ok(_adminService.GetByAdminNameAndPassword(adminLogIn));
        }

        [HttpPut]
        public IActionResult PutAdmin(string username, string password, AdminModel adminModel)
        {
            return Ok(_adminService.UpdateAdmin(username,password, adminModel));
        }
    }
}
