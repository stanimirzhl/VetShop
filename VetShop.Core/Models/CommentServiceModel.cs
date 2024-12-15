using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Core.Models
{
    public class CommentServiceModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? AuthorName { get; set; }
        public string? AuthorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ProductId { get; set; }
    }
}
