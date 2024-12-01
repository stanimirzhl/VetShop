using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Infrastructure.Data.Models;
using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Infrastructure.Data.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            var appointment = new Appointment
            {
                Id = 1,
                AppointmentDate = new DateTime(2024, 12, 05, 10, 30, 0),
                Reason = "Routine checkup",
                VeterinaryId = 1,
                UserId = "73a08f28-3434-45fe-b44c-90c7cae4916d",
                StatusOfAppointment = AppointmentStatus.Pending
            };
            builder.HasData(appointment);
        }
    }
}
