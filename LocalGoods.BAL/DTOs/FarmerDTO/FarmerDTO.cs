using LocalGoods.DAL.Models;
using LocalGoods.BAL.DTOs;
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
