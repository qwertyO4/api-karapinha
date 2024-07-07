namespace minhaprimeiraapi.Model
{
    public class AppointmentsModel
    {
        public int appointmentId { get; set; }
        public int userId { get; set; }
        public int professionalId { get; set; }
        public int serviceId { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly time { get; set; }
        public string status_appointment { get; set; }
        public decimal totalPrice { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}