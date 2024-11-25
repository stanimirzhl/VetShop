using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Infrastructure.Data.Configuration;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Infrastructure.Data
{
    public class VetShopDbContext : IdentityDbContext<ApplicationUser>
    {
        public VetShopDbContext(DbContextOptions<VetShopDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new CategoryConfigurator());


            base.OnModelCreating(modelBuilder);

        }
    }
}
