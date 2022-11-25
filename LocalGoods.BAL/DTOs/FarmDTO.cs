using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.BAL.DTOs
{
    public class FarmDTO
    {
        //[Key]
        //[SwaggerSchema(ReadOnly =true)]
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }
}
