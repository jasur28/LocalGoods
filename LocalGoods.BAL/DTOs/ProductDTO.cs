using LocalGoods.DAL.Models;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public QuantityTypes QuantityType { get; set; }

    }
}
