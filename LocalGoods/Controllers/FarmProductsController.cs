using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Implementation;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using System.Web.Http;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmProductsController : ControllerBase
    {
       
        private readonly IFarmProductsService farmProductsService;

        public FarmProductsController(IFarmProductsService farmProductsService)
        {
            this.farmProductsService = farmProductsService;
        }

        [HttpPost("{FarmID}/Add/{ProductID}")]
        public async Task<ActionResult<FarmProductsMapping>> Create(int FarmID,int ProductID,FarmProductsMappingDTO farm)
        {
            if (farm is null)
                return BadRequest();
            farm.ProductId= ProductID;
            farm.FarmId = FarmID;
            farm = await farmProductsService.Create(farm);
            return Ok(farm);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<FarmProductsMapping>> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            FarmProductsMappingDTO? farm = await farmProductsService.Get((int)id);
            if(farm is null)
            {
                return NotFound();
            }
            return Ok(farm);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int? id)
        {
            if(id==null)
            {
                return BadRequest();
            }
            bool u = await farmProductsService.Delete((int)id);
            return Ok(u);
        }
        [HttpGet]
        public async Task<ActionResult<List<FarmProductsMapping>>> GetAll()
        {
            return Ok(await farmProductsService.GetAll());
        }
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, FarmProductsMappingDTO? product)
        {
            if (product is null)
            {
                return BadRequest();
            }
            product.FarmProductId = id;
            product = await farmProductsService.Update(product);
            if (product != null)
            {
                return Ok(product);
            }
            return BadRequest();
        }
    }
}
