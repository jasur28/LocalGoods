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
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        public Decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Surplus { get; set; }
        [Required]
        [MinLength(5)]
        public string Image { get; set; }
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required]
        [ForeignKey("Farm")]
        public int FarmId { get; set; }
        [Required]
        [ForeignKey("QuantityType")]
        public int QuantityTypeId { get; set; }
        public Farm Farm { get; set; }
        public QuantityType QuantityType { get; set; }  
        public Category Category { get; set; }
      
    }
}
