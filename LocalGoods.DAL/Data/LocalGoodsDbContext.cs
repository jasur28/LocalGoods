using LocalGoods.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGoods.DAL.Data
{
    public class LocalGoodsDbContext : DbContext
    {
        public virtual DbSet<Farm> Farms { get; set; }
    }
}
