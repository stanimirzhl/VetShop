using System.ComponentModel.DataAnnotations;
using static VetShop.Infrastructure.Constants.DataConstants.ExceptionMessagesConstants;
using static VetShop.Infrastructure.Constants.DataConstants.BrandConstants;

namespace VetShop.Models.Brand
{
    public class BrandFormModel
    {
        [Required(ErrorMessage = BrandNameRequiredMessage)]
        [StringLength(MaxBrandName, MinimumLength = MinBrandName, ErrorMessage = BrandNameLengthMessage)]
        public string BrandName { get; set; } = null!;

        [Url(ErrorMessage = ImageUrlFormatMessage)]
        [Required(ErrorMessage = ImageUrlRequiredMessage)]
        public string ImageUrl { get; set; } = null!;
    }
}
