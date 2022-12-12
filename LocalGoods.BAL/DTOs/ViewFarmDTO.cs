using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LocalGoods.BAL.DTOs
{
    public class ViewFarmDTO : FarmDTO
    {
        public string ImagePath { get; set; }
        public int? Rating { get; set; }
    }
}
