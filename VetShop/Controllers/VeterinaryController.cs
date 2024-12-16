using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;
using VetShop.Core.Implementations;
using VetShop.Core.Interfaces;
using VetShop.Core.Models;
using VetShop.Infrastructure.Data.Models;
using VetShop.Models.Veterinary;
using static VetShop.Infrastructure.Constants.DataConstants;

namespace VetShop.Controllers
{
    public class VeterinaryController : Controller
    {
        private readonly IVeterinaryService veterinaryService;
        ILogger<VeterinaryController> logger;
        private readonly IAppointmentService appointmentService;

        public VeterinaryController(IVeterinaryService veterinaryService, ILogger<VeterinaryController> logger, IAppointmentService appointmentService)
        {
            this.veterinaryService = veterinaryService;
            this.logger = logger;
            this.appointmentService = appointmentService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var veterinaries = await veterinaryService.GetAllVeterinariansAsync();

            var mappedVeterinaries = veterinaries.Select(x => new VeterinaryViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                PhoneNumber = x.PhoneNumber,
                Specialty = x.Specialty,
                UserId = x.UserId,
                Appointment = new AppointmentFormView()
            });

            return View(mappedVeterinaries);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> MakeAppointment(int veterinaryId, AppointmentFormView model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("All");
            }
            if (!DateTime.TryParse(model.AppointmentDate, out DateTime addedOn))
            {
                ModelState.AddModelError(nameof(model.AppointmentDate), "Invalid date format.");
                model.AppointmentDate = string.Empty;
            }
            var appointment = new AppointmentServiceModel()
            {
                 AppointmentDate = addedOn,
                 Reason = model.Reason,
                 UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                 VeterinaryId = veterinaryId
            };
            TempData["SuccessMessage"] = "Appointment successfully made!";
            await appointmentService.CreateAppointmentAsync(appointment);

            return RedirectToAction("All");
        }
    }
}
