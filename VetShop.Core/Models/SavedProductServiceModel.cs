using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Core.Models
{
    public class SavedProductServiceModel
    {
        public string UserId { get; set; }

        public int ProductId { get; set; }
    }
}
