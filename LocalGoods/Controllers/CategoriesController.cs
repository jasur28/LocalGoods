using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Create(CategoryDTO category)
        {
            if (category is null)
                return BadRequest();
            category = await categoryService.Create(category);
            return Ok(category);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            CategoryDTO? category = await categoryService.Get((int)id);
            if (category is null)
                return NotFound();
            return Ok(category);
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            int statusOfOperation = await categoryService.Delete((int)id);
            if(statusOfOperation == 0)
            {
                return NotFound();
            }
            else if(statusOfOperation == 1)
            {
                return Ok("Deleted Successfully");
            }
            else if(statusOfOperation == 2)
            {
                return StatusCode(501);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetAll()
        {
            return Ok(await categoryService.GetAll());
        }

        [Authorize]
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, CategoryDTO category)
        {
            if (category is null)
            {
                return BadRequest();
            }
            category.Id = id;
            (category,int statusOfOperation) = await categoryService.Update((CategoryDTO)category);
            if (statusOfOperation == 1)
            {
                return Ok(category);
            }
            else if(statusOfOperation == 0)
            {
                return NotFound();
            }
            else if(statusOfOperation == 2)
            {
                return StatusCode(501);
            }
            return BadRequest();
        }
        [HttpGet("{id}/CategoryProducts")]
        public async Task<ActionResult<List<ProductDTO>>> GetCategoryProducts(int id)
        {
            (IEnumerable<ProductDTO> products, int statusOfOperation) = await categoryService.GetCategoryProducts(id);
            if(statusOfOperation == 0)
            {
                return NotFound();
            }
            else if(statusOfOperation == 1)
            {
                return Ok(products);
            }
            return StatusCode(501);
        }
    }
}
