using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace LocalGoods.DAL.Data
{
    public class LocalGoodsDbContext : IdentityDbContext<User>
    {
        public LocalGoodsDbContext(DbContextOptions<LocalGoodsDbContext> options)
            : base(options)
        {

        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public DbSet<QuantityType> QuantityTypes { get; set; }
    }
}
