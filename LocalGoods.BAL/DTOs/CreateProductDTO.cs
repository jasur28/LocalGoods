using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace LocalGoods.BAL.DTOs
{
    public class CreateProductDTO : ProductDTO
    {
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
