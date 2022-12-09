#nullable disable
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace LocalGoods.BAL.DTOs
{
    public class CreateFarmDTO : FarmDTO
    {
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
