using LocalGoods.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace LocalGoods.BAL.DTOs.UserDTO
{
#nullable disable
    public class CreateUserDTO
    {
        [Required]
        [MinLength(4)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TelePhone { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
