using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.DTOs.FarmerDTO;
using LocalGoods.BAL.Services.Implementation;
using LocalGoods.BAL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmersController : ControllerBase
    {
        private readonly IFarmerService _farmerService;
        public FarmersController(IFarmerService farmerService)
        {
            _farmerService = farmerService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateFarmerDTO>> Create(CreateFarmerDTO farm)
        {
            if (farm is null)
                return BadRequest();
            var createFarm = await _farmerService.Create(farm);

            return Ok(createFarm);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<FarmerDTO>> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            FarmerDTO farm = await _farmerService.Get((int)id);
            return Ok(farm);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var deleteFarm = await _farmerService.Delete(id);

            return Ok(deleteFarm);
        }

        [HttpGet]
        public async Task<ActionResult<List<FarmerDTO>>> GetAll()
        {
            return Ok(await _farmerService.GetAll());
        }

        [HttpPut]
        public async Task<ActionResult> Update(FarmerDTO farmerDTO)
        {
            var upadedFarm = await _farmerService.Update(farmerDTO);
            return Ok(upadedFarm);
        }
    }
}
