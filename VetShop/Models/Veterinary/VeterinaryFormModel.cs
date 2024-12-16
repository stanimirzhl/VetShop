using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VetShop.Infrastructure.Data.Models;
using static VetShop.Infrastructure.Constants.DataConstants.VeterinaryConstants;
using static VetShop.Infrastructure.Constants.DataConstants.ExceptionMessagesConstants;

namespace VetShop.Models.Veterinary
{
    public class VeterinaryFormModel
    {
        [Required(ErrorMessage = VeterinaryPhoneNumberMessage)]
        [Phone(ErrorMessage = VeterinaryPhoneNumberErrorMessage)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = VeterinarySpecialtyMessage)]
        [StringLength(MaxSpecialtyLength, MinimumLength = MinSpecialtyLength, ErrorMessage = VeterinarySpecialtyLengthMessage)]
        public string Specialty { get; set; } = null!;

        [Required(ErrorMessage = VeterinaryAddressMessage)]
        public string Address { get; set; } = null!;
    }
}
