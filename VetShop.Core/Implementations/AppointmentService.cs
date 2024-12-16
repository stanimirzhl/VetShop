using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Interfaces;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Common;
using VetShop.Infrastructure.Data.Models;
using static VetShop.Infrastructure.Constants.DataConstants.AppointmentStatus;

namespace VetShop.Core.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> repository;
        private ILogger<AppointmentService> logger;
        private readonly IVeterinaryService veterinaryService;

        public AppointmentService(IRepository<Appointment> repository, ILogger<AppointmentService> logger, IVeterinaryService veterinaryService)
        {
            this.repository = repository;
            this.logger = logger;
            this.veterinaryService = veterinaryService;
        }

        public async Task CreateAppointmentAsync(AppointmentServiceModel appointmentModel)
        {
            var appointment = new Appointment()
            {
                AppointmentDate = appointmentModel.AppointmentDate,
                Reason = appointmentModel.Reason,
                UserId = appointmentModel.UserId,
                VeterinaryId = appointmentModel.VeterinaryId,
            };

            await repository.AddAsync(appointment);
        }

        public async Task<AppointmentServiceModel> GetAppointmentByIdAsync(int id)
        {
            var appointment = await repository.GetByIdAsync(id);

            if (appointment == null) throw new NonExistentEntity($"Appointment with the given Id {id} does not exist.");

            var serviceAppointment = new AppointmentServiceModel()
            {
                AppointmentDate = appointment.AppointmentDate,
                Reason = appointment.Reason,
                UserId= appointment.UserId,
                VeterinaryId = appointment.VeterinaryId,
                Id = appointment.Id
            };

            return serviceAppointment;

        }

        public async Task<IEnumerable<AppointmentServiceModel>> GetAppointmentsByUserIdAsync(string userId)
        {
            var isVeterinary = await veterinaryService.IsVeterinary(userId);

            IQueryable<Appointment> appointments;

            if (isVeterinary)
            {
                appointments = repository.All()
                    .Where(a => a.Veterinary.UserId == userId)
                    .Include(a => a.User)
                    .Include(a => a.Veterinary)
                    .ThenInclude(v => v.User);
            }
            else
            {
                appointments = repository.All()
                    .Where(a => a.UserId == userId)
                    .Include(a => a.User)
                    .Include(a => a.Veterinary)
                    .ThenInclude(v => v.User);
            }

            var mappedAppointments = appointments.Select(x => new AppointmentServiceModel
            {
                AppointmentDate = x.AppointmentDate,
                Id = x.Id,
                Reason = x.Reason,
                VeterinaryName = x.Veterinary.User.FirstName + " " + x.Veterinary.User.LastName,
                AppointmentStatus = x.StatusOfAppointment,
                PhoneNumber = x.Veterinary.PhoneNumber,
                UsersName = x.User.FirstName + " " + x.Veterinary.User.LastName
            });

            return mappedAppointments;
        }

        public async Task AcceptAppointment(int id)
        {
            var appointment = await repository.GetByIdAsync(id);

            if (appointment == null) throw new NonExistentEntity($"Appointment with the given Id {id} does not exist.");

            appointment.StatusOfAppointment = Confirmed;

            await repository.SaveChangesAsync();

        }

        public async Task CancelAppointment(int id)
        {
            var appointment = await repository.GetByIdAsync(id);

            if (appointment == null) throw new NonExistentEntity($"Appointment with the given Id {id} does not exist.");

            appointment.StatusOfAppointment = Cancelled;

            await repository.SaveChangesAsync();
        }
    }
}
