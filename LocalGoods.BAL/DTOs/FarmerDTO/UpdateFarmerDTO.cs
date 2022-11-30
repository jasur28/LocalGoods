using LocalGoods.DAL.Models;

namespace LocalGoods.BAL.DTOs.FarmerDTO
{
    public class UpdateFarmerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
