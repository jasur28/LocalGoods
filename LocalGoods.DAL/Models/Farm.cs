using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Models
{
    public class Farm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [InverseProperty("Farm")]
        public virtual ICollection<FarmProductsMapping>? FarmProductMappings { get; set; }
    }
}
