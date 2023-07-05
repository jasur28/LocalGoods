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
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly TokenValidationParameters _tokenValidationParameters1;
        private readonly IAuthService authService;
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private object success;

        public AuthenticationController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration,
                TokenValidationParameters tokenValidationParameters1,
                IAuthService authService,
                IMapper mapper,
                IUserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _tokenValidationParameters1 = tokenValidationParameters1;
            this.authService = authService;
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Register([FromBody] RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please, provide all the required fields");
            }
            if (await userService.IsEmailAlreadyExisting(registerVM.EmailAddress))
            {
                return BadRequest($"User {registerVM.EmailAddress} already exists");
            }
            bool result=await userService.Create(mapper.Map<RegisterVM, User>(registerVM), registerVM.Password);
            if (result)
            {
                return Ok(await GenerateJWTTokenAsync(mapper.Map<RegisterVM,User>(registerVM)));
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

            var userExists = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (userExists != null && await _userManager.CheckPasswordAsync(userExists, loginVM.Password))
            {
                var tokenValue = await GenerateJWTTokenAsync(userExists);
                return Ok(tokenValue);
            }
            return Unauthorized();
        }
        private async Task<AuthResultVM> GenerateJWTTokenAsync(User user)
        {
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
            JwtSecurityToken securityToken = new(                                                
                                                 issuer: _configuration["JWT:Issuer"],
                                                 audience: _configuration["JWT:Audience"],
                                                 expires: DateTime.UtcNow.AddMinutes(60),
                                                 claims: authClaims,
                                                 signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                                                );
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(securityToken);
            var user1=await _userManager.FindByEmailAsync(user.Email);
            var authToken = new AuthToken()
            {
                Name = "Bearer Token",
                LoginProvider = "Custom",
                UserId = user1.Id,
                Value = securityToken.Id
            };
            await authService.Create(authToken);
            var response = new AuthResultVM()
            {
                Token = jwtToken,
                RefreshToken = authToken.Value,
                ExpiresAt = securityToken.ValidTo
            };
            return response;
        }
    }
}
