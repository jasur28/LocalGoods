using Swashbuckle.AspNetCore.Annotations;
#nullable disable
namespace LocalGoods.BAL.DTOs
{
    public class FarmDTO
    {
        [SwaggerSchema(ReadOnly =true)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [SwaggerSchema(ReadOnly =true)]
        public int FarmerId { get; set; }
    }
}
