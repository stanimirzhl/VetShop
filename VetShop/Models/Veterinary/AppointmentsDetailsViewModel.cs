namespace VetShop.Models.Veterinary
{
    public class AppointmentsDetailsViewModel
    {
        public IEnumerable<ApppointViewModel> Appointments { get; set; }

        public bool IsVeterinary { get; set; }
    }
}
