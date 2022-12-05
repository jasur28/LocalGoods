using LocalGoods.DAL.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
#nullable disable

namespace LocalGoods.BAL.DTOs
{
    public class AFarmProductDTO
    {
        [SwaggerSchema(ReadOnly =true)]
        public int Id { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public int ProductId { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public int FarmId { get; set; }
        [SwaggerSchema(ReadOnly =true)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int Surplus { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        [JsonIgnore(Condition=JsonIgnoreCondition.Always)]
        public int QuantityTypeId { get; set; }
    }
}
