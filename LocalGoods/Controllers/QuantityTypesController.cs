using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.Controllers
{
   // [Route("api/[controller]")]
    public class QuantityTypesController : ControllerBase
    {
        private readonly IQuantityTypeService QuantityTypeService;

        public QuantityTypesController(IQuantityTypeService QuantityTypeService)
        {
            this.QuantityTypeService = QuantityTypeService;
        }

      //  [HttpPost]
        public async Task<ActionResult<QuantityTypeDTO>> Create(QuantityTypeDTO QuantityType)
        {
            if (QuantityType is null)
                return BadRequest();
            QuantityType = await QuantityTypeService.Create(QuantityType);
            return Ok(QuantityType);
        }

       // [HttpGet("GetById/{id}")]
        public async Task<ActionResult<FarmDTO>> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            QuantityTypeDTO? QuantityType = await QuantityTypeService.Get((int)id);
            if (QuantityType is null)
                return NotFound();
            return Ok(QuantityType);
        }

//        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            bool i = await QuantityTypeService.Delete((int)id);
            return Ok(i);
        }
  //      [HttpGet]
        public async Task<ActionResult<List<QuantityTypeDTO>>> GetAll()
        {
            return Ok(await QuantityTypeService.GetAll());
        }
     //   [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, QuantityTypeDTO? QuantityType)
        {
            if (QuantityType is null)
            {
                return BadRequest();
            }
            QuantityType.Id = id;
            QuantityType = await QuantityTypeService.Update((QuantityTypeDTO)QuantityType);
            if (QuantityType != null)
            {
                return Ok(QuantityType);
            }
            return BadRequest();
        }
    }
}
