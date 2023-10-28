/*using ClaimManagement.DAL.Models;
using ClaimManagement.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ClaimManagement.DAL.Entity;

namespace InsuranceCompany.Controllers
{
    [AllowAnonymous]
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserAuthenticationService _userAuthenticationService;
        public AuthController(IConfiguration config, IUserAuthenticationService userAuthenticationService)
        {
            _config = config;
            _userAuthenticationService = userAuthenticationService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var authenticatedUser = _userAuthenticationService.Authenticate(user);

            if (authenticatedUser != null)
            {
                // Generate and return a JWT token
                var token = GenerateToken();
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username or password");
        }

        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}*/
