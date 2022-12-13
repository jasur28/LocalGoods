using LocalGoods.DAL.Helpers;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace LocalGoods.BAL.DTOs.UserDTO
{
    #nullable disable
    public class UserDTO
    {
        [SwaggerSchema(ReadOnly =true)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        [SwaggerSchema(ReadOnly =true)]
        public ICollection<string> Roles { get; set; }
    }
}
