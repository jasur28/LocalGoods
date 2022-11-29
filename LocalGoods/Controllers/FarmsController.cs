
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
        public async Task<ActionResult<CreateFarmDTO>> Create(CreateFarmDTO farmDTO)
        {
            if (farmDTO.Name is null)
                return BadRequest();
            var farm = await farmService.Create(farmDTO);

            return Ok(farm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FarmDTO>> GetById(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            FarmDTO farm = await farmService.Get(id);
            return Ok(farm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var farm = await farmService.Delete(id);

            return Ok(farm);
        }
        [HttpGet]
        public async Task<ActionResult<List<FarmDTO>>> GetAll()
        {
            return Ok(await farmService.GetAll());
        }
        [HttpPut]
        public async Task<ActionResult> Update(FarmDTO farmDTO)
        {
            var farm = await farmService.Update(farmDTO);
            return Ok(farm);
        }
    }
}
