using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.DTOs.UserDTO;
using LocalGoods.BAL.Services.Implementation;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        public UsersController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        [Authorize]
        [HttpGet("getidbysession")]
        public async Task<ActionResult<UserDTO>> GetIdBySession()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User user = await userManager.FindByIdAsync(userId);
            UserDTO dto = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles = await userManager.GetRolesAsync(user),
            };
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            UserDTO dto = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Roles=await userManager.GetRolesAsync(user)
            };
            return Ok(dto);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if(result.Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAll()
        {
            var users=await userManager.Users.ToListAsync();
            var dtos = new List<UserDTO>();
            foreach(var user in users)
            {
                IList<string> roles=await userManager.GetRolesAsync(user);
                dtos.Add(new UserDTO()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Roles = roles
                });
            }
            return Ok(dtos);
        }

        [Authorize]
        [HttpPost("UserId/BecomeAFarmer")]
        public async Task<ActionResult> BecomeAFarmer(string UserId)
        {
            User user = await userManager.FindByIdAsync(UserId);
            IdentityResult result=await userManager.AddToRoleAsync(user, DAL.Helpers.UserRoles.Farmer);
            if(result.Succeeded)
            {
                return Ok(user);
            }
            return StatusCode(501);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<UserDTO>> Update(UserDTO userDTO)
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var users=userManager.Users.Where(x => x.Id == id);
            if(!users.Any())
            {
                return NotFound("User Not Found");
            }
            User user = await userManager.FindByIdAsync(id);
            string email=user.Email;
            string username = user.UserName;
            var result=await userManager.SetEmailAsync(user,userDTO.Email);
            if (result.Succeeded)
            {
                result=await userManager.SetUserNameAsync(user, userDTO.UserName);
                if (result.Succeeded)
                {
                    userDTO.Id=user.Id;
                    userDTO.Roles = await userManager.GetRolesAsync(user);
                    return Ok(userDTO);
                }
                await userManager.SetEmailAsync(user,email);
                await userManager.SetUserNameAsync(user,username);
                return StatusCode(501, userDTO);
            }
            return StatusCode(501, new object[] { result });
        }
    }
}
