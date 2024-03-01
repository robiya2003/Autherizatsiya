using Application.Services.AuthServices;
using Domains.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public string LoInAuthentifikatsiyaForAdmin(AdminLogIn adminLogIn)
        {
            return _authService.GenerateTokenForAdmin(adminLogIn);
        }
        [HttpPost]
        public string LoInAuthentifikatsiyaForCustomer(CustomerLogIn customerLogIn)
        {
            return _authService.GenerateTokenForCustomer(customerLogIn);
        }
    }
}
