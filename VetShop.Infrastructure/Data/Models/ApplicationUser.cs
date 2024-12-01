using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VetShop.Infrastructure.Constants.DataConstants.UserConstants;

namespace VetShop.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(MaxUserFirstName)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(MaxUserLastName)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
