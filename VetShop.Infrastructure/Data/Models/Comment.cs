using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VetShop.Infrastructure.Constants.DataConstants.CommentConstants;
using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Infrastructure.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxCommentTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(MaxCommentDescription)]
        public string Description { get; set; } = null!;

        public DateTime DateTime { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Author))]
        public string? AuthorId { get; set; } = null!;

        public virtual ApplicationUser? Author { get; set; } = null!;

        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; } = null!;

        public virtual Product? Product { get; set; } = null!;

        public CommentStatus Status { get; set; } = CommentStatus.Pending;
    }
}
