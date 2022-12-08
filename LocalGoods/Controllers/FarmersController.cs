﻿using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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
        [HttpGet("{FarmerId}/Farms")]
        public async Task<ActionResult<List<FarmDTO>>> GetAllFarms(string FarmerId)
        {
            User farmer = await farmerManager.FindByIdAsync(FarmerId);
            var role=await roleManager.FindByIdAsync(DAL.Helpers.UserRoles.Farmer);
            
            if(farmer != null)
            {
                List<FarmDTO> farmDTOs = await farmService.GetAll();
                farmDTOs.Select(x => x.UserId == FarmerId);
                return farmDTOs;
            }
            return NotFound("Farmer Not Found");
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
