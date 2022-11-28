using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Create(ProductDTO product)
        {
            if (product is null)
                return BadRequest();
            product = await productService.Create(product);
            return Ok(product);
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<FarmDTO>> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            ProductDTO? product = await productService.Get((int)id);
            if(product is null)
                return NotFound();
            return Ok(product);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            bool i = await productService.Delete((int)id);
            return Ok(i);
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
            return Ok(await productService.GetAll());
        }
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id,ProductDTO? product)
        {
            if(product is null)
            {
                return BadRequest();
            }
            product.Id = id;
            product = await productService.Update((ProductDTO)product);
            if(product != null)
            {
                return Ok(product);
            }
            return BadRequest();
        }
    }
}
