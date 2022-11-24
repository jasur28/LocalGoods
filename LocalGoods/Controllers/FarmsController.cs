
using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
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
        public async Task<ActionResult<FarmDTO>> Create(FarmDTO farm)
        {
            if (farm is null)
                return BadRequest();
            var createFarm = await farmService.Create(farm);

            return Ok(createFarm);
        }

        [HttpGet]
        public async Task<ActionResult<FarmDTO>> Get(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            FarmDTO farm = await farmService.Get(id);
            return Ok(farm);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var deleteFarm = await farmService.Delete(id);

            return Ok(deleteFarm);
        }
    }
}
