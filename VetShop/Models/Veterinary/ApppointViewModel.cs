﻿using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Models.Veterinary
{
    public class ApppointViewModel
    {
        public int Id { get; set; }

        public string VeterinaryName { get; set; } = null!;

        public DateTime AppointmentDate { get; set; }

        public string Reason { get; set; } = null!;

        public string PhoneNumber { get; set; }

        public string? UsersName { get; set; }

        public AppointmentStatus AppointmentStatus { get; set; }
    }
}
