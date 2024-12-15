using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VetShop.Infrastructure.Constants.DataConstants.ProductConstants;
namespace VetShop.Infrastructure.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxProductTitle)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(MaxProductDescription)]
        public string Description { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        [ForeignKey(nameof(Brand))]
        public int? BrandId { get; set; }

        public Brand Brand { get; set; }

        [Required]
        public int Quantity { get; set; } = 0;

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<SavedProduct> SavedProducts { get; set; } = new List<SavedProduct>();

        public bool IsDeleted { get; set; } = false;

        public bool IsActive => Quantity > 0;

    }
}
