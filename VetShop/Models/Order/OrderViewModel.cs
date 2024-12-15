using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Models.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public OrderStatus Status { get; set; }

        public decimal TotalPrice { get; set; }

        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
    }
}
