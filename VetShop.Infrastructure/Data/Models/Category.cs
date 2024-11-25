using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static VetShop.Infrastructure.Constants.DataConstants.Category;

namespace VetShop.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxCategoryName)]
        public string Name { get; set; } = string.Empty;

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
