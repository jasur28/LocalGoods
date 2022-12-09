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
        //[Required]
        //public string Image { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        public int? Rating { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public string UserId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FaceBook { get; set; }
        [Required]
        public string Instagram { get; set; }
        [SwaggerSchema(ReadOnly =true)]
        public List<ProductDTO> Products { get; set; }
    }
}
