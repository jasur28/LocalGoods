using LocalGoods.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;
using System.Text.Json.Serialization;

namespace LocalGoods.BAL.DTOs
{
    public class FarmProductsMappingDTO
    {
        [SwaggerSchema(ReadOnly =true)]
        public int FarmProductId { get; set; }
        [SwaggerSchema(ReadOnly =true)]
        public int ProductId { get; set; }
        [SwaggerSchema(ReadOnly =true)]
        public int FarmId { get; set; }
        public string? Description { get; set; }
        public int? Surplus { get; set; }
        public decimal? Price { get; set; }
    }
}
