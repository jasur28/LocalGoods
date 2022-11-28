namespace LocalGoods.DAL.Models
{
    public class Farm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int FarmerId { get; set; }
        public virtual Farmer Farmer { get; set; }
    }
}
