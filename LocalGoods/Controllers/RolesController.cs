using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService RoleService;

        public RolesController(IRoleService RoleService)
        {
            this.RoleService = RoleService;
        }

        [HttpPost]
        public async Task<ActionResult<RoleDTO>> Create(RoleDTO Role)
        {
            if (Role is null)
                return BadRequest();
            Role = await RoleService.Create(Role);
            return Ok(Role);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<FarmDTO>> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            RoleDTO? Role = await RoleService.Get((int)id);
            if (Role is null)
                return NotFound();
            return Ok(Role);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            bool i = await RoleService.Delete((int)id);
            return Ok(i);
        }
        [HttpGet]
        public async Task<ActionResult<List<RoleDTO>>> GetAll()
        {
            return Ok(await RoleService.GetAll());
        }
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, RoleDTO? Role)
        {
            if (Role is null)
            {
                return BadRequest();
            }
            Role.Id = id;
            Role = await RoleService.Update((RoleDTO)Role);
            if (Role != null)
            {
                return Ok(Role);
            }
            return BadRequest();
        }
    }
}
