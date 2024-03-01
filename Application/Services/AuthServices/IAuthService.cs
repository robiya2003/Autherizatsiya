using Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthServices
{
    public interface IAuthService
    {
        public string GenerateTokenForAdmin(AdminLogIn adminLogIn);
        public string GenerateTokenForCustomer(CustomerLogIn customerLogIn);
    }
}
