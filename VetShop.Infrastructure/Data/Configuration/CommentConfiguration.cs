using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Infrastructure.Data.Models;
using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Infrastructure.Data.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(c => c.Author)
            .WithMany(c => c.Comments)
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.SetNull);

            builder.HasData(new Comment
            {
                Id = 1,
                Title = "Great product!",
                Description = "This product made wonders for my pet.",
                AuthorId = "73a08f28-3434-45fe-b44c-90c7cae4916d",
                ProductId = 1,
                Status = CommentStatus.Approved
            });
        }
    }
}
