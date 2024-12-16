using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Core.Models
{
    public class AppointmentServiceModel
    {
        public DateTime AppointmentDate { get; set; }

        public string Reason { get; set; } = null!;

        public int VeterinaryId { get; set; }

        public string UserId { get; set; } = null!;

        public int Id { get; set; }

        public string VeterinaryName { get; set; } = null!;

        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
