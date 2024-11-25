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
    public class CategoryConfigurator : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Cats"
                },
                new Category()
                {
                    Id= 2,
                    Name = "Dogs"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Others"
                }
            };
            builder.HasData(categories);
        }
    }
}
