using LocalGoods.DAL.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace LocalGoods.BAL.DTOs
{
    public class ProductDTO
    {
        [SwaggerSchema(ReadOnly =true)]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [SwaggerSchema(ReadOnly =true)]
        public int FarmId { get; set; }
        //public int QuantityTypeId { get; set; }
        //public int Surplus { get; set; }

    }
}
