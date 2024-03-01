using Application.IRepositories;
using Domains.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private  readonly IAdminRepository _adminRepository;
        private readonly ICustomerRepository _customerRepository;
        public AuthService(IAdminRepository adminRepository,
            ICustomerRepository customerRepository,
            IConfiguration configuration)
        {
            _adminRepository = adminRepository;
            _customerRepository = customerRepository;
            _configuration = configuration;
        }
        public string GenerateTokenForAdmin(AdminLogIn adminLogIn)
        {
            if(AdminExists(adminLogIn)) 
            {
                // 1-usul
                var issuer = _configuration.GetSection("JWT");
                var secretkey = issuer["Secret"];
                // 2-usul
                var key = _configuration["JWT:Secret"];



                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim("Username",adminLogIn.Adminname),
                    new Claim("password",adminLogIn.Password),
                    new Claim("datetime",DateTime.UtcNow.ToString())
                };


                return GenerateToken(claims);

            }
            else
            {
                return "Admin not found";
            }
        }

        public string GenerateTokenForCustomer(CustomerLogIn customerLogIn)
        {
            if(CustomerExist(customerLogIn))
            {
                return "";
            }
            else
            {
                return "Customer not found";
            }
        }

        public  string GenerateToken(IEnumerable<Claim> additionalClaims)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var exDate = Convert.ToInt32(_configuration["JWT:ExpireDate"] ?? "10");

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture), ClaimValueTypes.Integer64)
            };

            if (additionalClaims?.Any() == true)
                claims.AddRange(additionalClaims);


            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(exDate),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



















            private bool AdminExists(AdminLogIn adminLogIn)
        {
            var admin=_adminRepository.EnterAdmin(adminLogIn);
            if (admin == null)
            {
                return false;
            }
            return true;
        }
        private bool CustomerExist(CustomerLogIn customerLogIn)
        {
            var customer=_customerRepository.EnterUser(customerLogIn);
            if(customer == null)
            {
                return false;
            }
            return true;
        }
    }
}
