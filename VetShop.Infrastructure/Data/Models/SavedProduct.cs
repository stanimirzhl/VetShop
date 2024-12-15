using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetShop.Infrastructure.Data.Models
{
    public class SavedProduct
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

}
