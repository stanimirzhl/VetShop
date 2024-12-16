using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Models;

namespace VetShop.Core.Interfaces
{
    public interface IAppointmentService
    {
        Task CreateAppointmentAsync(AppointmentServiceModel appointmentModel);
        Task<AppointmentServiceModel> GetAppointmentByIdAsync(int id);
        Task<IEnumerable<AppointmentServiceModel>> GetAppointmentsByUserIdAsync(string userId);
        Task AcceptAppointment(int id);
        Task CancelAppointment(int id);
    }
}
