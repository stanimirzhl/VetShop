using System.ComponentModel.DataAnnotations;

namespace VetShop.Models.Product
{
    public class ProductDeleteViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

        public string BrandName { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; } = null!;
    }
}
