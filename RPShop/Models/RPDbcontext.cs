using Microsoft.EntityFrameworkCore;
using RPShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Models
{
    public class RPDbcontext : DbContext
    {
        public RPDbcontext(DbContextOptions<RPDbcontext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<supplier> suppliers { get; set; }
        public DbSet<typeProduct> typeProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
