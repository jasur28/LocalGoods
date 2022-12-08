using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.DTOs.UserDTO;
using LocalGoods.BAL.Services.Implementation;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                //TelePhone = user.PhoneNumber,
                //Address = user.Address,
                //City = user.City,
                //Country = user.Country,
                //FirstName= user.FirstName,
                //LastName= user.LastName,
                //Instagram=user.Instagram,
                //Facebook=user.FaceBook
            };
            return Ok(dto);
        }

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
                    //TelePhone = user.PhoneNumber,
                    //Address = user.Address,
                    //City = user.City,
                    //Country = user.Country,
                    //FirstName = user.FirstName,
                    //LastName = user.LastName,
                    //Instagram = user.Instagram,
                    //Facebook = user.FaceBook
                });
            }
            return Ok(dtos);
        }


        //[HttpPut("{id}")]
        //public async Task<ActionResult<UserDTO>> Update(int id, UserDTO farmerDTO)
        //{
        //    if (id != farmerDTO.Id)
        //    {
        //        return BadRequest();
        //    }


        //    var farmer = await userManager.C
        //    return Ok(farmer);
        //}
    }
}
