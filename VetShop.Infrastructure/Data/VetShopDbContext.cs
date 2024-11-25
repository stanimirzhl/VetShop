using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Infrastructure.Data
{
    public class VetShopDbContext : IdentityDbContext<ApplicationUser>
    {

    }
}
