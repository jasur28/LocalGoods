using LocalGoods.BAL.Interfaces;
using LocalGoods.BAL.Operations;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        private readonly IFarmRepository farmRepository;

        public FarmsController(IFarmRepository farmRepository)
        {
            this.farmRepository = farmRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Farm>> Post(Farm farm)
        {
            if (farm is null)
                return BadRequest();
            var f = await farmRepository.Create(farm);

            return Ok(f);
        }
    }
}
