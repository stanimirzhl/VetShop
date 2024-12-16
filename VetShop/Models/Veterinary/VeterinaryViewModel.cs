namespace VetShop.Models.Veterinary
{
    public class VeterinaryViewModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Specialty { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public AppointmentFormView Appointment { get; set; } = new AppointmentFormView();
    }
}
