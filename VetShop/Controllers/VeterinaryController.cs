using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;
using VetShop.Core;
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
                TempData["ErrorMessage"] = "Error in creating an appointment, please try again!";
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> MyAppointments()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var appointments = await appointmentService.GetAppointmentsByUserIdAsync(userId);

            var isVeterinery = await veterinaryService.IsVeterinary(userId);

            var mappedAppointments = appointments.Select(x => new ApppointViewModel
            {
                Id = x.Id,
                AppointmentDate = x.AppointmentDate,
                VeterinaryName = x.VeterinaryName,
                Reason = x.Reason,
                AppointmentStatus = x.AppointmentStatus,
                PhoneNumber = x.PhoneNumber,
                UsersName = x.UsersName,
            });

            var details = new AppointmentsDetailsViewModel()
            {
                Appointments = mappedAppointments,
                IsVeterinary = isVeterinery
            };

            return View(details);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AcceptAppointment(int id)
        {
            try
            {
                await appointmentService.AcceptAppointment(id);
            }
            catch (NonExistentEntity ex)
            {
                return NotFound();
            }

            return RedirectToAction("MyAppointments");
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CancelAppointment(int id)
        {
            try
            {
                await appointmentService.CancelAppointment(id);
            }
            catch (NonExistentEntity ex)
            {
                return NotFound();
            }

            return RedirectToAction("MyAppointments");
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> BecomeVeterinary()
        {
            return View(new VeterinaryFormModel());
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> BecomeVeterinary(VeterinaryFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("BecomeVeterinary", model);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (await veterinaryService.IsVeterinary(userId))
            {
                TempData["UserExists"] = "You are already a veterinary.";
                return RedirectToAction("BecomeVeterinary");
            }

            if(await veterinaryService.UserWithPhoneNumberExists(model.PhoneNumber))
            {
                TempData["PhoneExists"] = "There is already existing vet with such number, please try different one.";
                return RedirectToAction("BecomeVeterinary");
            }

            await veterinaryService.BecomeVeterinaryAsync(userId, model.PhoneNumber, model.Specialty, model.Address);

            TempData["SuccessMessage"] = "Successfully sent form to become a veterinary.";
            return RedirectToAction("Index");
        }
    }
}
