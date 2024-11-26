using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Infrastructure.Data.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            var brands = new List<Brand>()
            {
                 new Brand { Id = 1, BrandName = "Hill’s Science Diet" },
                 new Brand { Id = 2, BrandName = "Royal Canin" },
                 new Brand { Id = 3, BrandName = "Pedigree" },
                 new Brand { Id = 4, BrandName = "Purina" },
                 new Brand { Id = 5, BrandName = "Blue Buffalo" },
                 new Brand { Id = 6, BrandName = "Wellness" },
                 new Brand { Id = 7, BrandName = "Iams" },
                 new Brand { Id = 8, BrandName = "Orijen" },
                 new Brand { Id = 9, BrandName = "Acana" },
                 new Brand { Id = 10, BrandName = "Nature’s Logic" },
                 new Brand { Id = 11, BrandName = "Merrick" },
                 new Brand { Id = 12, BrandName = "Canidae" },
                 new Brand { Id = 13, BrandName = "Natural Balance" },
                 new Brand { Id = 14, BrandName = "Taste of the Wild" },
                 new Brand { Id = 15, BrandName = "Solid Gold" },
                 new Brand { Id = 16, BrandName = "KONG" },
                 new Brand { Id = 17, BrandName = "Chuckit!" },
                 new Brand { Id = 18, BrandName = "Nerf Dog" },
                 new Brand { Id = 19, BrandName = "Outward Hound" },
                 new Brand { Id = 20, BrandName = "PetSafe" },
                 new Brand { Id = 21, BrandName = "JW Pet" },
                 new Brand { Id = 22, BrandName = "Frisco" },
                 new Brand { Id = 23, BrandName = "Trixie" },
                 new Brand { Id = 24, BrandName = "ZippyPaws" },
                 new Brand { Id = 25, BrandName = "BarkBox" },
                 new Brand { Id = 26, BrandName = "Planet Dog" },
                 new Brand { Id = 27, BrandName = "Multipet" },
                 new Brand { Id = 28, BrandName = "Ethical Pet" },
                 new Brand { Id = 29, BrandName = "Petstages" },
                 new Brand { Id = 30, BrandName = "PetQwerks" },
                 new Brand { Id = 31, BrandName = "Petmate" },
                 new Brand { Id = 32, BrandName = "Snoozer Pet Products" },
                 new Brand { Id = 33, BrandName = "K&H Pet Products" },
                 new Brand { Id = 34, BrandName = "Ruffwear" },
                 new Brand { Id = 35, BrandName = "FurHaven Pet Products" },
                 new Brand { Id = 36, BrandName = "MidWest Homes for Pets" },
                 new Brand { Id = 37, BrandName = "Armarkat" },
                 new Brand { Id = 38, BrandName = "Merrick" },
                 new Brand { Id = 39, BrandName = "Litter Genie" },
                 new Brand { Id = 40, BrandName = "Trixie Pet Products" },
                 new Brand{Id = 41, BrandName = "Gourmet" }
            };
            builder.HasData(brands);
        }
    }
}
