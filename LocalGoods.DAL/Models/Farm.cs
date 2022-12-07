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
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; } 
        public string Country { get; set; }
        public string Image { get; set; }
        //public decimal Latitude { get; set; }
        //public decimal Longitude { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Rating { get; set; }
        public string UserId { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string FaceBook { get; set; }
        public string Instagram { get; set; }
        public ICollection<Product> Products { get; set; }
        public User User { get; set; }
       
    }
}
