using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Infrastructure.Data.Configuration
{
    public class VeterinaryConfiguration : IEntityTypeConfiguration<Veterinary>
    {
        public void Configure(EntityTypeBuilder<Veterinary> builder)
        {
            builder.HasOne(v => v.User)
                .WithOne()
                .HasForeignKey<Veterinary>(v => v.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Veterinary
                {
                    Id = 1,
                    PhoneNumber = "987-654-3210",
                    Specialty = "Dermatology",
                    UserId = "cb2e865b-c700-40b6-af4f-9ed7429ac4bc",
                    Address = "24 Kapitan Dimitar Spisarevski"
                }
            );
        }
    }

}
