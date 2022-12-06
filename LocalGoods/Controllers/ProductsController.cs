using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Implementation;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
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

        [HttpPost("{FarmId}")]
        public async Task<ActionResult<ProductDTO>> Create(int FarmId,ProductDTO productDTO)
        {
            productDTO.FarmId = FarmId;
            (ProductDTO createdProduct, int i) = await productService.Create(productDTO);
            if (i == 0)
            {
                return NotFound("Farm Not Found");
            }
            else if (i == 1)
            {
                return Ok(createdProduct);
            }
            else if (i == 2)
            {
                return StatusCode(501,productDTO);
            }
            else
            {
                return BadRequest(productDTO);
            }
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            int i = await productService.Delete((int)id);
            if (i == 1)
            {
                return Ok("Deleted Successfully");
            }
            else if (i == 0)
            {
                return NotFound();
            }
            else if (i == 2)
            {
                return StatusCode(501);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAll()
        {
            return Ok(await productService.GetAll());
        }
        //Under Development
        //[HttpPut("Update/{id}")]
        //public async Task<ActionResult> Update(int id,ProductDTO? product)
        //{
        //    if (product is null)
        //    {
        //        return BadRequest();
        //    }
        //    product.Id = id;
        //    (product, int a) = await productService.Update(product);
        //    if (a == 1)
        //    {
        //        return Ok(product);
        //    }
        //    else if (a == 0)
        //    {
        //        return NotFound();
        //    }
        //    else if (a == 2)
        //    {
        //        return StatusCode(501);
        //    }
        //    return BadRequest();
        //}
    }
}
