using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public ApplicationUser? User { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public decimal TotalPrice => OrderItems.Sum(x => x.Quantity * (x.Product?.Price ?? 0m));
    }

}
