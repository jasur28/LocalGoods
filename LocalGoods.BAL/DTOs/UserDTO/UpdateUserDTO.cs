using LocalGoods.DAL.Models;

namespace LocalGoods.BAL.DTOs.UserDTO
{
#nullable disable
    public class UpdateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TelePhone { get; set; }
    }
}
