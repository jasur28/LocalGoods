using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LocalGoods.Core.Models
{
#nullable disable
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("UpdatedUser")]
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}