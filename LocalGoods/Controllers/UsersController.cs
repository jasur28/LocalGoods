using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.DTOs.UserDTO;
using LocalGoods.BAL.Services.Implementation;
using LocalGoods.BAL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserDTO>> Create(CreateUserDTO farmerDTO)
        {
            if (farmerDTO.FirstName is null)
                return BadRequest();

            var farmer = await userService.Create(farmerDTO);

            return Ok(farmer);
        }
        [HttpGet("{FarmerId}/Farms")]
        public async Task<ActionResult<List<FarmDTO>>> GetAll(int FarmerId)
        {
            return Ok(await userService.GetFarms(FarmerId));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetById(int id)
        {
            UserDTO farmer = await userService.Get(id);
            return Ok(farmer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var farmer=await userService.Get(id);
            if (farmer != null)
            {
                var status = await userService.Delete(farmer);
                return true;
            }

            return false;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> GetAll()
        {
            return Ok(await userService.GetAll());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Update(int id, UserDTO farmerDTO)
        {
            if (id != farmerDTO.Id)
            {
                return BadRequest();
            }


            var farmer = await userService.Update(farmerDTO);
            return Ok(farmer);
        }
    }
}
