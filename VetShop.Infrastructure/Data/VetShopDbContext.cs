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
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Veterinary> Veterinaries { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<SavedProduct> SavedProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Veterinary)
            .WithMany(x => x.Appointments) 
            .HasForeignKey(x => x.VeterinaryId)
            .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.User)
                .WithMany(x => x.Appointments)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SavedProduct>()
            .HasKey(sp => new { sp.UserId, sp.ProductId });

            modelBuilder.Entity<SavedProduct>()
                .HasOne(sp => sp.User)
                .WithMany(u => u.SavedProducts)
                .HasForeignKey(sp => sp.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SavedProduct>()
                .HasOne(sp => sp.Product)
                .WithMany(p => p.SavedProducts)
                .HasForeignKey(sp => sp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfigurator());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new VeterinaryConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());

            base.OnModelCreating(modelBuilder);

        }
    }
}
