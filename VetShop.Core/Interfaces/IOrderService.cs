using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Core.Interfaces
{
    public interface IOrderService
    {
        Task AddProductToOrderAsync(int productId, int quantity, string userId);
        Task<Order> GetOrCreateOrderAsync(string userId);
        Task<IEnumerable<OrderServiceModel>> GetAllAsync(string userId);
        Task<OrderServiceModel> GetByIdAsync(int id, string userId);
        Task RemoveOrderItemAsync(string userId, int orderItemId);
        Task<bool> CompleteOrderAsync(string userId);
    }
}
