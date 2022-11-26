using LocalGoods.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace LocalGoods.DAL.Data
{
    public class LocalGoodsDbContext : DbContext
    {
        public LocalGoodsDbContext(DbContextOptions<LocalGoodsDbContext> options)
            : base(options)
        {

        }
        public virtual DbSet<Farm> Farms { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<FarmProductsMapping> FarmProductsMappings { get; set; }
    }
}
