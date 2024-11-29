using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VetShop.Infrastructure.Constants.DataConstants.VeterinaryConstants;

namespace VetShop.Infrastructure.Data.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)]
    public class Veterinary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = null!;

        [MaxLength(MaxSpecialtyLength)]
        public string Specialty { get; set; } = null!;

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }

}
