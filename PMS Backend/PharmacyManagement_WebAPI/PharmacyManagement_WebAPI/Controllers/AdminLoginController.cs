using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PharmacyManagement_WebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PharmacyManagement_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        private IConfiguration _configuration;
        
        public AdminLoginController(IConfiguration configuration)
        {
            _configuration = configuration;
           
        }
        [HttpPost]
        public IActionResult Login([FromBody]LoginDetails login)
        {
            var user = Authenticate(login);
            if (user != null)
            {
                var token = Generate(user);
                var obj = new { Token = token };
                return Ok(obj);

            }
            return BadRequest();
        }
        private string Generate(Admin user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var claims = new[]
                {
                new Claim(ClaimTypes.Email,user.AdminEmail),
                new Claim(ClaimTypes.NameIdentifier,user.AdminPassword),
                new Claim(ClaimTypes.NameIdentifier,user.AdminName),
                //new Claim(ClaimTypes.MobilePhone,user.AdminPhone),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                                             _configuration["Jwt:Audience"],
                                             claims,
                                             expires: DateTime.Now.AddMinutes(20),
                                             signingCredentials: credentials
                                             );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        private Admin Authenticate(LoginDetails adminlogin)
        {
            var CurrentUser = AdminList._admin.FirstOrDefault(
                c => c.AdminEmail.ToLower() == adminlogin.EmailId.ToLower()
                && c.AdminPassword == adminlogin.Password);
            if (CurrentUser != null)
            {
                return CurrentUser;
            }
            return null;
        }
    }
}
