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
        public async Task<ActionResult<FarmDTO>> Create(int UserId, FarmDTO farmDTO)
        {
            farmDTO.UserId = UserId;
            (FarmDTO createdFarm,int i) = await farmService.Create(farmDTO);
            if(i==0)
            {
                return NotFound("User Not Found");
            }
            else if(i==1)
            {
                return Ok(createdFarm);
            }
            else if(i==2)
            {
                return StatusCode(501);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<FarmDTO>>> Get()
        {
            return Ok(await farmService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FarmDTO>> GetById(int id)
        {
            FarmDTO? farm = await farmService.Get((int)id);
            if(farm is null)
            {
                return NotFound();
            }
            return Ok(farm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            int i = await farmService.Delete((int)id);
            if(i==1)
            {
                return Ok("Deleted Successfully");
            }
            else if(i==0)
            {
                return NotFound();
            }
            else if(i==2)
            {
                return StatusCode(501);
            }
            return BadRequest();
         }
        //Under development
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(int id,FarmDTO farmDTO)
        //{
        //    farmDTO.Id = id;
        //    (farmDTO,int i) = await farmService.Update(farmDTO);
        //    if(i==1)
        //    {
        //        return Ok(farmDTO);
        //    }
        //    else if(i==0)
        //    {
        //        return NotFound("Farm Not Found");
        //    }
        //    else if(i==2)
        //    {
        //        return StatusCode(501);
        //    }
        //    return BadRequest();
        //}
        [HttpGet("{id}/FarmProducts")]
        public async Task<ActionResult> FarmProducts(int id)
        {
            (List<ProductDTO> products, int i) = await farmService.GetProducts(id);
            if(i==0)
            {
                return NotFound("Farm Not Found");
            }
            else if(i==1)
            {
                return Ok(products);
            }
            return Ok(products);
        }
    }
}
