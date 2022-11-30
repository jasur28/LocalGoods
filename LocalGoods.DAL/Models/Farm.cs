using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace LocalGoods.DAL.Models
{
    public class Farm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Latitude { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Longitude { get; set; }
        [ForeignKey("Farmer")]
        public int FarmerId { get; set; }
        public virtual Farmer Farmer { get; set; }
        [InverseProperty("Farm")]
        public virtual ICollection<FarmProductsMapping> FarmProductMappings { get; set; }
    }
}
