using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Implementations;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Common;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Core.Interfaces
{
    public interface IOrderItemService
    {
        Task AddOrderItem(int orderId, int productId, int quantiy);

        Task RemoveOrderItem(int id);
    }
}
