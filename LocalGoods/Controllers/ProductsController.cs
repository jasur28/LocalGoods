using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Implementation;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Security.Claims;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IFarmService farmService;

        public ProductsController(IProductService productService, IWebHostEnvironment hostEnvironment, IFarmService farmService)
        {
            this.productService = productService;
            this.hostEnvironment = hostEnvironment;
            this.farmService = farmService;
        }
        [Authorize(Roles ="Farmer")]
        [HttpPost("{FarmId}")]
        public async Task<ActionResult<ProductDTO>> Create(int FarmId,[FromForm]CreateProductDTO productDTO)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(productDTO);
                productDTO.FarmId = FarmId;
                string Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                FarmDTO? farm = await farmService.Get(FarmId);
                if(farm is not null && farm.UserId!= Id)
                {
                    return BadRequest("Not permitted");
                }
                (ProductDTO createdProduct, int statusOfOperation) = await productService.Create(productDTO,uniqueFileName);
                if (statusOfOperation == 0)
                {
                    return NotFound("Farm Not Found");
                }
                else if (statusOfOperation == 1)
                {
                    return Ok(createdProduct);
                }
                else if (statusOfOperation == 2)
                {
                    return StatusCode(501, productDTO);
                }
                else
                {
                    return BadRequest(productDTO);
                }
            }
            return BadRequest(productDTO);
           
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<CreateProductDTO>> GetById(int? id)
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
        [Authorize(Roles ="Farmer")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            int statusOfOperation = await productService.Delete((int)id);
            if (statusOfOperation == 1)
            {
                return Ok(true);
            }
            else if (statusOfOperation == 0)
            {
                return NotFound();
            }
            else if (statusOfOperation == 2)
            {
                return StatusCode(501);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<ActionResult<List<ViewProductDTO>>> GetAll()
        {
            return Ok(await productService.GetAll());
        }
        [Authorize(Roles ="Farmer")]
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(int id, [FromForm]CreateProductDTO productDTO)
        {
            if(ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(productDTO);
                string uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                ProductDTO? product = await productService.Get(id);
                if (product is not null)
                {
                    FarmDTO? farm = await farmService.Get(product.FarmId);
                    if(farm is not null && farm.UserId != uid)
                    {
                        return BadRequest();
                    }
                    productDTO.Id = id;
                    (ProductDTO viewProductDTO, int statusOfOperation) = await productService.Update(productDTO, uniqueFileName);
                    if (statusOfOperation == 1)
                    {
                        return Ok(viewProductDTO);
                    }
                    else if (statusOfOperation == 0)
                    {
                        return NotFound("Farm Not Found");
                    }
                    else if (statusOfOperation == 2)
                    {
                        return StatusCode(501, productDTO);
                    }
                    return BadRequest();

                }
                else
                {
                    return NotFound("Product Not Found");
                }
            }
            return BadRequest(productDTO);
        }
        private string ProcessUploadedFile(CreateProductDTO model)
        {
            string uniqueFileName="";

            if (model.ImageFile != null)
            {
                string uploadsFolder = hostEnvironment.WebRootPath;
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder+"/Images/Products/"+ uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageFile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
