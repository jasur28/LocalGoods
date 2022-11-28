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
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
    }
}
