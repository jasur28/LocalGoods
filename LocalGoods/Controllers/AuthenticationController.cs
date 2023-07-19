using AutoMapper;
using LocalGoods.API.Resources;
using LocalGoods.Core.Models;
using LocalGoods.Core.Services;
using LocalGoods.DAL.Migrations;
using LocalGoods.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LocalGoods.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService authService;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public AuthenticationController(IConfiguration configuration,
                IAuthService authService,
                IMapper mapper,
                IUserService userService)
        {
            _configuration = configuration;
            this.authService = authService;
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Register([FromBody] RegisterVM registerVM)
        {
            if (await userService.IsEmailAlreadyExisting(registerVM.EmailAddress))
            {
                return BadRequest($"User {registerVM.EmailAddress} already exists");
            }
            bool result=await userService.Create(mapper.Map<RegisterVM, User>(registerVM), registerVM.Password);
            if (result)
            {
                User user = await userService.GetUserByEmail(registerVM.EmailAddress);
                return Ok(new { Token = await GenerateJWTTokenAsync(user) });
            }
            return BadRequest("User could not be created");
        }

        [HttpPost("login-user")]
        public async Task<IActionResult> Login([FromBody] LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please, provide all required fields");
            }
            if (await userService.AreCorrectCredentialsEntered(loginVM.EmailAddress, loginVM.Password))
            {
                User user=await userService.GetUserByEmail(loginVM.EmailAddress);
                var tokenString = await GenerateJWTTokenAsync(user);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }

        private async Task<string> GenerateJWTTokenAsync(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: _configuration["JWT:Secret"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                };
            var roles = await userService.GetUserRoles(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );
            return tokenHandler.WriteToken(token);
        }
    }
}
