using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
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
            bool i = await categoryService.Delete((int)id);
            return Ok(i);
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetAll()
        {
            return Ok(await categoryService.GetAll());
        }
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, CategoryDTO? category)
        {
            if (category is null)
            {
                return BadRequest();
            }
            category.Id = id;
            category = await categoryService.Update((CategoryDTO)category);
            if (category != null)
            {
                return Ok(category);
            }
            return BadRequest();
        }
        [HttpGet("{id}/CategoryProducts")]
        public async Task<ActionResult<List<ProductDTO>>> GetCategoryProducts(int id)
        {
            return Ok(await categoryService.GetCategoryProducts(id));
        }
    }
}
