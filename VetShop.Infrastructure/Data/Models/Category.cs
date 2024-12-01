using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static VetShop.Infrastructure.Constants.DataConstants.CategoryConstants;

namespace VetShop.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxCategoryName)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
