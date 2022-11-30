using LocalGoods.BAL.DTOs;
using LocalGoods.BAL.Services.Implementation;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace LocalGoods.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        private readonly IFarmerService farmerService;
        private readonly IFarmService farmService;
        private readonly IFarmProductsService farmProductsService;
        private readonly IProductService productService;

        public FarmsController(IFarmService farmService, IFarmProductsService farmProductsService, IProductService productService, IFarmerService farmerService)
        {
            this.farmService = farmService;
            this.farmProductsService = farmProductsService;
            this.productService = productService;
            this.farmerService = farmerService;
        }

        [HttpPost("{FarmerId}")]
        public async Task<ActionResult<CreateFarmDTO>> Create(int FarmerId, FarmDTO farmDTO)
        {
            if (farmDTO.Name is null)
                return BadRequest();
            farmDTO.FarmerId = FarmerId;
            FarmDTO? createdFarm = await farmService.Create(farmDTO);
            if (createdFarm is null)
            {
                return BadRequest();
            }
            return Ok(createdFarm);
        }
        [HttpGet]
        public async Task<ActionResult<List<FarmDTO>>> Get()
        {
            return Ok(await farmService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FarmDTO>> GetById(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            FarmDTO? farm = await farmService.Get((int)id);
            if(farm is null)
            {
                return NotFound();
            }
            return Ok(farm);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            bool i = await farmService.Delete((int)id);
            return Ok(i);
         }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,FarmDTO? farmDTO)
        {
            if (farmDTO is null)
            {
                return BadRequest();
            }
            farmDTO.Id = id;
            farmDTO = await farmService.Update((FarmDTO)farmDTO);
            if (farmDTO != null)
            {
                return Ok(farmDTO);
            }
            return BadRequest();
        }
        [HttpPost("{FarmId}/Products/{id}")]
        public async Task<ActionResult<FarmProductsMappingDTO?>> CreateMapping(int FarmId, int id, AFarmProductDTO mappingDTO)
        {
            if (mappingDTO is null)
                return BadRequest();
            FarmProductsMappingDTO farmProductsMapping = new()
            {
                ProductId = id,
                FarmId = FarmId,
                Price = mappingDTO.Price,
                Description = mappingDTO.Description,
                Surplus = mappingDTO.Surplus
            };
            FarmProductsMappingDTO? createdMapping = await farmProductsService.Create(farmProductsMapping);
            if (createdMapping != null)
            {
                if(createdMapping.FarmProductId == 0)
                {
                    return NotFound("Product Already Exists in the farm");
                }
                return Ok(createdMapping);
            }
            return BadRequest();
        }

        [HttpGet("{FarmId}/Products")]
        public async Task<ActionResult<List<FarmProductsMappingDTO>>> GetProducts(int FarmId)
        {
            List<FarmProductsMappingDTO> products = await farmService.GetProducts(FarmId);
            return Ok(products);
        }
        [HttpGet("Products/{id}")]
        public async Task<ActionResult<FarmProductsMappingDTO?>> GetFarmProduct(int id)
        {
            FarmProductsMappingDTO? product = await farmProductsService.Get(id);
            if(product==null)
                return NotFound();
            return Ok(product);
        }
       
        [HttpPut("Products/{id}")]
        public async Task<ActionResult<FarmProductsMappingDTO>> EditProduct(int id, AFarmProductDTO productDTO)
        {
            if (productDTO is null)
                return BadRequest();
            FarmProductsMappingDTO farmProductsMappingDTO = new()
            {
                FarmProductId = id,
                Price = productDTO.Price,
                Surplus = productDTO.Surplus,
                Description=productDTO.Description,
            };
            FarmProductsMappingDTO? editedMapping = await farmProductsService.Update(farmProductsMappingDTO);
            if(editedMapping!=null)
                return Ok(editedMapping);
            return NotFound();
        }
        [HttpDelete("Products/{id}")]
        public async Task<ActionResult<bool>> DeleteMapping(int id, AFarmProductDTO productDTO)
        {
            return await farmProductsService.Delete(id);
        }
    }
}
