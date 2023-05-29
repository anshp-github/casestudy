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
    public class DoctorLoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly PharmacyDbContext _context;
        public DoctorLoginController(IConfiguration configuration, PharmacyDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginDetails login)
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
        private string Generate(DoctorRegistration user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                {
                new Claim(ClaimTypes.Email,user.DocEmail),
                new Claim(ClaimTypes.NameIdentifier,user.DocPassword),
                new Claim(ClaimTypes.NameIdentifier,user.DocName),
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
        private DoctorRegistration Authenticate(LoginDetails adminlogin)
        {
            var CurrentUser = _context.Doctors.FirstOrDefault(
                c => c.DocEmail.ToLower() == adminlogin.EmailId.ToLower()
                && c.DocPassword == adminlogin.Password);
            if (CurrentUser != null)
            {
                return CurrentUser;
            }
            return null;
        }
    }
}
