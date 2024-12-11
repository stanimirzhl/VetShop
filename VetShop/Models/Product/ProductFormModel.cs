using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static VetShop.Infrastructure.Constants.DataConstants.ExceptionMessagesConstants;
using static VetShop.Infrastructure.Constants.DataConstants.ProductConstants;

namespace VetShop.Models.Product
{
    public class ProductFormModel
    {
        [Required(ErrorMessage = ProductTitleRequiredMessage)]
        [StringLength(MaxProductTitle, MinimumLength = MinProductTitle, ErrorMessage = ProductTitleLengthMessage)]
        public string Title { get; set; } = null!;

        [Range(typeof(decimal),MinProductPrice, MaxProductPrice, ErrorMessage = ProductPriceLengthMessage)]
        public decimal Price { get; set; }

        [Url(ErrorMessage = ImageUrlFormatMessage)]
        [Required(ErrorMessage = ImageUrlRequiredMessage)]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = ProductCategoryIdRequiredMessage)]
        public int? CategoryId { get; set; }

        [Required(ErrorMessage = ProductBrandIdRequiredMessage)]
        public int? BrandId { get; set; }

        [Required(ErrorMessage = ProductDescriptionRequiredMessage)]
        [StringLength(MaxProductDescription, MinimumLength = MinProductDescription, ErrorMessage = ProductDescriptionLengthMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = ProductQuantityRequiredMessage)]
        [Range(MinProductQuantity, int.MaxValue, ErrorMessage = ProductQuantityMessage)]
        public int Quantity {  get; set; }

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Brands { get; set; } = new List<SelectListItem>();
    }
}
