using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace LocalGoods.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public int FarmId { get; set; }
        public int? Surplus { get; set; } = 100;
        public int QuantityTypeId { get; set; } =1;
        public Farm Farm { get; set; }
        public QuantityType QuantityType { get; set; }  
        public Category Category { get; set; }
      
    }
}
