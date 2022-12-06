using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace LocalGoods.DAL.Models
{
    public class Farm
    {
        public int Id { get; set; }
        [MinLength(5)]
        [Required]
        public string Name { get; set; }
        [MinLength(5)]
        [Required]
        public string Address { get; set; }
        [MinLength(5)]
        [Required]
        public string City { get; set; }
        [MinLength(5)]
        [Required]
        public string Country { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Rating { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string FaceBook { get; set; }
        public string Instagram { get; set; }
        public ICollection<Product> Products { get; set; }
        public User User { get; set; }
       
    }
}
