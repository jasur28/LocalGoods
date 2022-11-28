using Swashbuckle.AspNetCore.Annotations;

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
