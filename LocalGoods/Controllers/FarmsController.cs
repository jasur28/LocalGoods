using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Implementation;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        private readonly IUserService farmerService;
        private readonly IFarmService farmService;
        private readonly IProductService productService;

        public FarmsController(IFarmService farmService,IProductService productService, IUserService farmerService)
        {
            this.farmService = farmService;
            this.productService = productService;
            this.farmerService = farmerService;
        }

        [HttpPost("{UserId}")]
        public async Task<ActionResult<CreateFarmDTO>> Create(int UserId, FarmDTO farmDTO)
        {
            if (farmDTO.Name is null)
                return BadRequest();
            farmDTO.UserId = UserId;
            FarmDTO? createdFarm = await farmService.Create(farmDTO);
            if (createdFarm is null)
            {
                return BadRequest();
            }
            return Ok(createdFarm);
        }
        [HttpGet]
        public async Task<ActionResult<List<FarmDTO>>> Get()
        {
            return Ok(await farmService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FarmDTO>> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            FarmDTO? farm = await farmService.Get((int)id);
            if(farm is null)
            {
                return NotFound();
            }
            return Ok(farm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            int i = await farmService.Delete((int)id);
            if(i==1)
            {
                return Ok("Deleted Successfully");
            }
            else if(i==0)
            {
                return NotFound();
            }
            return StatusCode(501);
         }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,FarmDTO? farmDTO)
        {
            if (farmDTO is null)
            {
                return BadRequest();
            }
            farmDTO.Id = id;
            farmDTO = await farmService.Update((FarmDTO)farmDTO);
            if (farmDTO != null)
            {
                return Ok(farmDTO);
            }
            return BadRequest();
        }
    }
}
