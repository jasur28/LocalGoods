using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.DTOs.FarmerDTO
{
    public class FarmerDTO
    {
        //[Key]
        //[SwaggerSchema(ReadOnly =true)]
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
