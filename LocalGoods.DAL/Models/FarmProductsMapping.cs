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
    public class FarmProductsMapping
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int FarmId { get; set; }
        public string Description { get; set; }
        public int Surplus { get; set; }
        public decimal Price { get; set; }
        public virtual Farm Farm { get; set; }
        public virtual Product Product { get; set; }
    }
}
