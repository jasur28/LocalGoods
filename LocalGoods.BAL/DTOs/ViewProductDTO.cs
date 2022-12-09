using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace LocalGoods.BAL.DTOs
{
    public class ViewProductDTO : ProductDTO
    {
        public string ImagePath { get; set; }
    }
}
