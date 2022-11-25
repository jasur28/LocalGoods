
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

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<FarmDTO>> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            FarmDTO farm = await farmService.Get((int)id);
            return Ok(farm);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var deleteFarm = await farmService.Delete(id);

            return Ok(deleteFarm);
        }
        [HttpGet]
        public async Task<ActionResult<List<FarmDTO>>> GetAll()
        {
            return Ok(await farmService.GetAll());
        }
        [HttpPut]
        public async Task<ActionResult> Update(FarmDTO farmDTO)
        {
            var upadedFarm = await farmService.Update(farmDTO);
            return Ok(upadedFarm);
        }
    }
}
