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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int FarmerId { get; set; }
        public virtual Farmer Farmer { get; set; }
        [InverseProperty("Farm")]
        public virtual ICollection<FarmProductsMapping> FarmProductMappings { get; set; }
    }
}
