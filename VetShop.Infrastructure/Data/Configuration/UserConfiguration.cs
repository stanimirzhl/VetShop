using Microsoft.AspNetCore.Identity;
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
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var user1 = new ApplicationUser()
            {
                Id = "73a08f28-3434-45fe-b44c-90c7cae4916d",
                UserName = "Guest User",
                Email = "guest@gmail.com",
                FirstName = "Guest",
                LastName = "User"
            };
            user1.PasswordHash = hasher.HashPassword(user1, "guest123");
            var user2 = new ApplicationUser()
            {
                Id = "cb2e865b-c700-40b6-af4f-9ed7429ac4bc",
                UserName = "Guest2 User",
                Email = "guest2@gmail.com",
                FirstName = "Guest2",
                LastName = "User"
            };
            user2.PasswordHash = hasher.HashPassword(user2, "guestN123");

            builder.HasData(user1, user2);
        }
    }
}
