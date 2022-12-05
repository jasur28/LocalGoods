using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace LocalGoods.DAL.Models
{
    public class Farmer 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [InverseProperty("Farmer")]
        public virtual ICollection<Farm> Farms { get; set; }
    }
}
