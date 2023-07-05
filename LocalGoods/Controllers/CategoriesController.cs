using AutoMapper;
using LocalGoods.Core.Models;
using LocalGoods.Core.Services;
using LocalGoods.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IUserService userService;
        public CategoriesController(ICategoryService categoryService,IMapper mapper, IUserService userService)
        {
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var categories=await categoryService.GetAllCategories();
            return Ok(categories);
        }
        [Authorize(Roles ="Farmer")]
        [HttpPost]
        public async Task AddCategory([FromBody] CategoryResource category)
        {
            var claims = HttpContext.User.Claims;
            var userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;        
            await categoryService.Create(mapper.Map<CategoryResource, Category>(category), userId);
        }

    }
}
