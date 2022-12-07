using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

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

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            int i = await categoryService.Delete((int)id);
            if(i==0)
            {
                return NotFound();
            }
            else if(i==1)
            {
                return Ok("Deleted Successfully");
            }
            else if(i==2)
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
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, CategoryDTO category)
        {
            if (category is null)
            {
                return BadRequest();
            }
            category.Id = id;
            (category,int a) = await categoryService.Update((CategoryDTO)category);
            if (a==1)
            {
                return Ok(category);
            }
            else if(a==0)
            {
                return NotFound();
            }
            else if(a==2)
            {
                return StatusCode(501);
            }
            return BadRequest();
        }
        [HttpGet("{id}/CategoryProducts")]
        public async Task<ActionResult<List<ProductDTO>>> GetCategoryProducts(int id)
        {
            (IEnumerable<ProductDTO> products, int a) = await categoryService.GetCategoryProducts(id);
            if(a == 0)
            {
                return NotFound();
            }
            else if(a==1)
            {
                return Ok(products);
            }
            return StatusCode(501);
        }
    }
}
