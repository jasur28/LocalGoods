using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Helpers;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LocalGoods.Controllers
{
    [Authorize(Roles = UserRoles.Farmer)]
    [Route("api/[controller]")]
    [ApiController]
    public class FarmersController : ControllerBase
    {
        private readonly UserManager<User> farmerManager;
        private readonly IFarmService farmService;
        public FarmersController(UserManager<User> farmerManager, IFarmService farmService)
        {
            this.farmerManager = farmerManager;
            this.farmService = farmService;
        }
        [HttpGet("{FarmerId}/Farms")]
        public async Task<ActionResult<List<FarmDTO>>> GetAllFarms(string FarmerId)
        {
            List<FarmDTO> farmDTOs = await farmService.GetAll();
            farmDTOs.Select(x => x.UserId == FarmerId);
            return farmDTOs;
        }
        [HttpPost("UserId")]
        public async Task<ActionResult> AssignFarmerRole(string UserId)
        {
            User user=await farmerManager.FindByIdAsync(UserId);
            await farmerManager.AddToRoleAsync(user, DAL.Helpers.UserRoles.Farmer);
            return Ok(user);
        }
        [HttpGet]
        public async Task<ActionResult> AllFarmers()
        {
            var farmers=await farmerManager.GetUsersInRoleAsync(DAL.Helpers.UserRoles.Farmer);
            return Ok(farmers);
        }
    }
}
