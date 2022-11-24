
using LocalGoods.BAL.Services;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        private readonly IFarmService farmService;

        public FarmsController(IFarmService farmService)
        {
            this.farmService = farmService;
        }

        [HttpPost]
        public async Task<ActionResult<Farm>> Post(Farm farm)
        {
            if (farm is null)
                return BadRequest();
            var f = await farmService.AddFarm(farm);

            return Ok(f);
        }
    }
}
