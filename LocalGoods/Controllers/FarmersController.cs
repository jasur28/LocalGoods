using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Helpers;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmersController : ControllerBase
    {
        private readonly UserManager<User> farmerManager;
        private readonly IFarmService farmService;
        private readonly RoleManager<IdentityRole> roleManager;
        public FarmersController(UserManager<User> farmerManager, IFarmService farmService, RoleManager<IdentityRole> roleManager)
        {
            this.farmerManager = farmerManager;
            this.farmService = farmService;
            this.roleManager = roleManager;
        }
        [Authorize(Roles = "Farmer")]
        [HttpGet("MyFarms")]
        public async Task<ActionResult<List<ViewFarmDTO>>> GetMyFarms()
        {
            string FarmerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            User farmer = await farmerManager.FindByIdAsync(FarmerId);
            var role=await roleManager.FindByIdAsync(DAL.Helpers.UserRoles.Farmer);
            
            if(farmer != null)
            {
                IEnumerable<ViewFarmDTO> farmDTOs = await farmService.GetAll();
                farmDTOs = farmDTOs.Where(x => x.UserId == FarmerId);
                return Ok(farmDTOs);
            }
            return NotFound("Farmer Not Found");
        }
        [HttpGet]
        public async Task<ActionResult> AllFarmers()
        {
            var farmers=await farmerManager.GetUsersInRoleAsync(DAL.Helpers.UserRoles.Farmer);
            List<FarmerDTO> dtos = new List<FarmerDTO>();
            foreach (var farmer in farmers)
            {
                FarmerDTO farmerDTO = new()
                {
                    Id = farmer.Id,
                    UserName = farmer.UserName,
                    Email = farmer.Email,
                    Roles = await farmerManager.GetRolesAsync(farmer),
                };
                dtos.Add(farmerDTO);
            }

            return Ok(dtos);
        }
    }
}
