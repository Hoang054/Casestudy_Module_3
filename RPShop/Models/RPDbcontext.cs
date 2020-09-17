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
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<Oder> Oders { get; set; }
        public DbSet<OderDetail> OderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Linventory> Linventorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OderDetail>().HasKey(c => new { c.idOder, c.idProduct });
            //modelBuilder.Ignore<Supplier>();
            //modelBuilder.Ignore<TypeProduct>();
        }
    }
}
