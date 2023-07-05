using System.ComponentModel.DataAnnotations;

namespace LocalGoods.API.Resources
{
    public class TokenRequestVM
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string RefreshToken { get; set; }
    }
}
