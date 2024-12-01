using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetShop.Infrastructure.Data.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Order))]
        public int? OrderId { get; set; } 

        public Order? Order { get; set; } 

        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }  

        public Product? Product { get; set; }

        public int Quantity { get; set; } 
    }
}
