using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
#nullable disable
namespace LocalGoods.BAL.DTOs
{
    public class FarmDTO
    {
        [SwaggerSchema(ReadOnly =true)]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public string Image { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Rating { get; set; }
        [SwaggerSchema(ReadOnly =true)]
        public string UserId { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string FaceBook { get; set; }
        public string Instagram { get; set; }
    }
}
