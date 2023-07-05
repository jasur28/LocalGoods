using LocalGoods.Core.Models;

namespace LocalGoods.API.Resources
{
    public class RefreshTokenVM
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateExpire { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
