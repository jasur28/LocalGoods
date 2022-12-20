using LocalGoods.DAL.Configurations;
using LocalGoods.Core.Models;
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

       // public DbSet<RefreshToken> RefreshTokens { get; set; }
     //   public DbSet<Farm> Farms { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<QuantityType> QuantityTypes { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.ApplyConfiguration(new ProductConfiguration());
        //    builder.ApplyConfiguration(new UserConfiguration());
        //    builder.ApplyConfiguration(new CategoryConfiguration());
        //}
    }
}
