using LocalGoods.BAL.Operations;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private readonly FarmOperation farmOperation;

        public FarmController(FarmOperation operation)
        {
            farmOperation = operation;
        }


        //POST
        [HttpPost]
        public async Task<ActionResult<Farm>> Create(Farm item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            await farmOperation.Create(item);
            return Ok();
        }
    }
}
