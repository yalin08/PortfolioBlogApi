using Business.Dto.User;
using Business.Services.Interface;
using Infrastructure.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PortfolioBlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        public UserController(IUserService userService, UserManager<AppUser> userManager, IConfiguration config)
        {
            _userService = userService;
            _userManager = userManager;
            _configuration = config;
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> Register(RegisterDto model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var result = await _userService.Register(model);
        //    if (result.Succeeded)
        //    {
        //        return Ok(new { message = "User registered successfully" });
        //    }
        //    return BadRequest(new { message = "User registration failed" });
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var result = await _userService.Login(model);
            if (result.Succeeded)
            {
             
                var authClaims = new List<Claim> {
                    new Claim(ClaimTypes.Email,model.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                var token = GetToken(authClaims);
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(jwt);
            }
            return Unauthorized(new { message = "Invalid username or password" });
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var a = _configuration["JwtSettings:SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                _configuration["JwtSettings:validIssuer"],
                _configuration["JwtSettings:validAudience"],
                authClaims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signIn
                );

            return token;
        }
    }
}
