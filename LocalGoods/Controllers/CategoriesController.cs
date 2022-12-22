using AutoMapper;
using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        public CategoriesController(ICategoryService categoryService,IMapper mapper)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var categories=await categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpPost]
        public async Task AddCategory([FromBody] CategoryDto category)
        {
            await categoryService.Create(category);
        }

    }
}
