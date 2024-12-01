using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VetShop.Infrastructure.Constants.DataConstants;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Infrastructure.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            var orders = new List<Order>
            {
                 new Order
                 {
                     Id = 1,
                     UserId = "73a08f28-3434-45fe-b44c-90c7cae4916d",
                     Status = OrderStatus.Pending,
                 },
                 new Order
                 {
                     Id = 2,
                     UserId = "cb2e865b-c700-40b6-af4f-9ed7429ac4bc",
                     Status = OrderStatus.Delivered,
                 }
            };
            builder.HasData(orders);
        }
    }
}
