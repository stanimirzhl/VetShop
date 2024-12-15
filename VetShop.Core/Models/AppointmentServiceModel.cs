using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetShop.Core.Models
{
    public class AppointmentServiceModel
    {
        public DateTime AppointmentDate { get; set; }

        public string Reason { get; set; } = null!;

        public int VeterinaryId { get; set; }

        public string UserId { get; set; } = null!;
    }
}
