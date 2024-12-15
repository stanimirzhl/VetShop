using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Interfaces;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Common;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Core.Implementations
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRepository<OrderItem> repository;
        private ILogger<OrderItemService> logger;

        public OrderItemService(IRepository<OrderItem> repository, ILogger<OrderItemService> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        public async Task AddOrderItem(int orderId, int productId, int quantiy)
        {
            var orderItem = new OrderItem()
            {
                OrderId = orderId,
                ProductId = productId,
                Quantity = quantiy
            };
            await repository.AddAsync(orderItem);
        }

        public async Task RemoveOrderItem(int id)
        {
            var order = await repository.GetByIdAsync(id);
            if (order == null) throw new NonExistentEntity("Order item does not exist.");

            await repository.DeleteAsync(order.Id);
        }
    }
}
