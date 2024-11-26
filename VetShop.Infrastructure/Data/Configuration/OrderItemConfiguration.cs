using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Infrastructure.Data.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasOne(oi => oi.Order)
                 .WithMany(o => o.OrderItems)
                 .HasForeignKey(oi => oi.OrderId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.SetNull);
            var orderItems = new List<OrderItem>
            {
                 new OrderItem
                 {
                     Id = 1,
                     OrderId = 1,
                     ProductId = 1,
                     Quantity = 4
                 },
                 new OrderItem
                 {
                     Id = 2,
                     OrderId = 1,
                     ProductId = 2,
                     Quantity = 1
                 },
                 new OrderItem
                 {
                     Id = 3,
                     OrderId = 2,
                     ProductId = 3,
                     Quantity = 3
                 },
                 new OrderItem
                 {
                     Id = 4,
                     OrderId = 2,
                     ProductId = 6,
                     Quantity = 10
                 },
                 new OrderItem
                 {
                     Id = 3,
                     OrderId = 2,
                     ProductId = 5,
                     Quantity = 2
                 }
            };

            builder.HasData(orderItems);
        }
    }
}
