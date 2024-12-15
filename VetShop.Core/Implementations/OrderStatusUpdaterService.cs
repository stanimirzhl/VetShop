using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VetShop.Infrastructure.Data;
using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Services
{
    public class OrderStatusUpdaterService : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;

        public OrderStatusUpdaterService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<VetShopDbContext>();
                    await UpdateOrderStatusesAsync(dbContext);
                }

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }

        private async Task UpdateOrderStatusesAsync(VetShopDbContext dbContext)
        {
            var fiveDaysAgo = DateTime.UtcNow.AddDays(-5);

            var ordersToDeliver = dbContext.Orders
                .Where(o => o.Status == OrderStatus.Sent && o.OrderDate <= fiveDaysAgo);

            foreach (var order in ordersToDeliver)
            {
                order.Status = OrderStatus.Delivered;
            }

            if (ordersToDeliver.Any())
            {
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
