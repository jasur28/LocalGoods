namespace LocalGoods.DAL.Models
{
    public class Farmer 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Farm> Farms { get; set; }
    }
}
