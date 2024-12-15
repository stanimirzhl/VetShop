using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetShop.Core.Models
{
    public class OrderItemServiceModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal ProductPrice { get; set; }

        public string ImageUrl { get; set; }
    }
}
