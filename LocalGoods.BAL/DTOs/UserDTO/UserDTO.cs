using System.ComponentModel.DataAnnotations;

namespace LocalGoods.BAL.DTOs.UserDTO
{
    #nullable disable
    public class UserDTO
    {
        public string Id { get; set; }
        [Required]
        [MinLength(5)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TelePhone { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }    
        public string Address { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
    }
}
