using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Core.Models
{
    public class OrderServiceModel
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public decimal TotalPrice { get; set; }

        public List<OrderItemServiceModel> OrderItems { get; set; } = new List<OrderItemServiceModel>();
    }
}
