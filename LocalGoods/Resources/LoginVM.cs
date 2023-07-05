using System.ComponentModel.DataAnnotations;
#nullable disable
namespace LocalGoods.API.Resources
{
    public class LoginVM
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
