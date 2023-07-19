using System.ComponentModel.DataAnnotations;
#nullable disable
namespace LocalGoods.API.Resources
{
    public class RegisterVM
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
        public bool IsFarmer { get; set; } = false;
    }
}
