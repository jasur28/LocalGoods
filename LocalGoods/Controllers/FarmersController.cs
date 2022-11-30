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
        public async Task<ActionResult<CreateFarmerDTO>> Create(CreateFarmerDTO farmerDTO)
        {
            if (farmerDTO.FirstName is null)
                return BadRequest();

            var farmer = await _farmerService.Create(farmerDTO);

            return Ok(farmer);
        }
        [HttpGet("{FarmerId}/Farms")]
        public async Task<ActionResult<List<FarmDTO>>> GetAll(int FarmerId)
        {
            return Ok(await _farmerService.GetFarms(FarmerId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FarmerDTO>> GetById(int id)
        {
            FarmerDTO farmer = await _farmerService.Get(id);
            return Ok(farmer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var farmer=await _farmerService.Get(id);
            if (farmer != null)
            {
                var status = await _farmerService.Delete(farmer);
                return true;
            }

            return false;
        }

        [HttpGet]
        public async Task<ActionResult<List<FarmerDTO>>> GetAll()
        {
            return Ok(await _farmerService.GetAll());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<FarmerDTO>> Update(int id, FarmerDTO farmerDTO)
        {
            if (id != farmerDTO.Id)
            {
                return BadRequest();
            }


            var farmer = await _farmerService.Update(farmerDTO);
            return Ok(farmer);
        }
    }
}
