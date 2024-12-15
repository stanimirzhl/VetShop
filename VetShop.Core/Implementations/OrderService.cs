using Microsoft.EntityFrameworkCore;
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
using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Core.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> repository;
        private ILogger<OrderService> logger;
        private readonly IOrderItemService orderItemService;

        public OrderService(IRepository<Order> repository, ILogger<OrderService> logger, IOrderItemService orderItemService)
        {
            this.repository = repository;
            this.logger = logger;
            this.orderItemService = orderItemService;
        }

        public async Task AddProductToOrderAsync(int productId, int quantity, string userId)
        {
            var order = await this.GetOrCreateOrderAsync(userId);

            var existingOrderItem = order.OrderItems.FirstOrDefault(oi => oi.ProductId == productId);

            if (existingOrderItem != null)
            {
                existingOrderItem.Quantity += quantity;
            }
            else
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = productId,
                    Quantity = quantity
                };
                order.OrderItems.Add(orderItem);
            }
            await repository.SaveChangesAsync();
        }
        public async Task<Order> GetOrCreateOrderAsync(string userId)
        {
            var order = await repository.All()
                .Include(o => o.OrderItems).ThenInclude(o => o.Product)
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == OrderStatus.Pending);

            if (order == null)
            {
                order = new Order
                {
                    UserId = userId,
                    Status = OrderStatus.Pending,
                    OrderItems = new List<OrderItem>()
                };
                await repository.AddAsync(order);
            }
            return order;
        }

        public async Task<IEnumerable<OrderServiceModel>> GetAllAsync(string userId)
        {
            var orders = repository.All().Where(x => x.UserId == userId).Include(x => x.OrderItems).ThenInclude(x => x.Product);

            var serviceOrders = await orders.Select(x => new OrderServiceModel
            {
                Id = x.Id,
                UserId = x.UserId,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                Status = x.Status,
            }).ToListAsync();

            return serviceOrders;
        }

        public async Task<OrderServiceModel> GetByIdAsync(int id, string userId)
        {
            var order = await repository.All()
                .Where(o => o.Id == id && o.UserId == userId)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product).FirstOrDefaultAsync();

            if (order == null) throw new NonExistentEntity($"Order with Id {id} does not exist.");

            var serviceOrder = new OrderServiceModel()
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Status = order.Status,
                TotalPrice = order.TotalPrice,
                UserId = order.UserId,
                OrderItems = order.OrderItems.Select(x => new OrderItemServiceModel
                {
                    ProductName = x.Product.Title,
                    ProductPrice = x.Product.Price,
                    Quantity =  x.Quantity,
                    ImageUrl = x.Product.ImageUrl,
                    Id = x.Id
                }).ToList()
            };

            return serviceOrder;
        }
        public async Task RemoveOrderItemAsync(string userId, int orderItemId)
        {
            var order = await repository.All()
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == OrderStatus.Pending);

            if (order != null)
            {
                await orderItemService.RemoveOrderItem(orderItemId);
                await repository.SaveChangesAsync();
            }
        }
        public async Task<bool> CompleteOrderAsync(string userId)
        {
            var order = await repository.All()
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == OrderStatus.Pending);

            if (order == null || !order.OrderItems.Any())
            {
                return false; 
            }

            order.Status = OrderStatus.Sent;

            await repository.SaveChangesAsync();

            return true;
        }
    }
}
