using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VetShop.Infrastructure.Constants.DataConstants.AppointmentConstants;
using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Infrastructure.Data.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public DateTime AppointmentDate { get; set; }

        [MaxLength(MaxReasonLength)]
        public string Reason { get; set; } = null!;

        [ForeignKey(nameof(Veterinary))]
        public int VeterinaryId { get; set; }

        public Veterinary? Veterinary { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; } 

        public ApplicationUser? User { get; set; }

        public AppointmentStatus StatusOfAppointment { get; set; } = AppointmentStatus.Pending;
    }

}
