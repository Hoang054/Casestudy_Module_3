using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RPShop.Models.Entities;

namespace RPShop.Models
{
    public class RPDbcontext : IdentityDbContext<ApplicationUser>
    {
        public RPDbcontext(DbContextOptions<RPDbcontext> options) : base(options)
        {

        }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<OrderOnline> OrderOnlines { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Inventory> Inventorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Replay> Replays { get; set; }
        public DbSet<Vote> Votes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderDetail>().HasKey(c => new { c.OrderOnlineId, c.ProductId });
            //modelBuilder.Ignore<Customer>();
            //modelBuilder.Ignore<Employees>();
            //modelBuilder.Ignore<Supplier>();
            //modelBuilder.Ignore<TypeProduct>();
            //modelBuilder.Ignore<Product>();

            //modelBuilder.Ignore<OrderOnline>();
            //modelBuilder.Ignore<Image>();
            //modelBuilder.Ignore<Inventory>();

            //modelBuilder.Ignore<OrderDetail>();

        }
    }
}
