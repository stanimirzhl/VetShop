using static VetShop.Infrastructure.Constants.DataConstants.AppointmentConstants;
using static VetShop.Infrastructure.Constants.DataConstants.ExceptionMessagesConstants;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Models.Veterinary
{
    public class AppointmentFormView
    {
        [Required(ErrorMessage = AppointmentRequiredMessage)]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [StringLength(MaxReasonLength, MinimumLength = MinReasonLength, ErrorMessage = AppointReasonLengthMessage)]
        public string Reason { get; set; } = null!;

        public int VeterinaryId { get; set; }

        public string UserId { get; set; } = null!;

    }
}
