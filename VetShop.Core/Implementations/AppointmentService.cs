using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Interfaces;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Common;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Core.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<Appointment> repository;
        private ILogger<AppointmentService> logger;

        public AppointmentService(IRepository<Appointment> repository, ILogger<AppointmentService> logger)
        {
            this.repository = repository;
            this.logger = logger;
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

        public Task<AppointmentServiceModel> GetAppointmentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentServiceModel>> GetAppointmentsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AppointmentServiceModel>> GetAppointmentsByVeterinaryIdAsync(int veterinaryId)
        {
            throw new NotImplementedException();
        }
    }
}
