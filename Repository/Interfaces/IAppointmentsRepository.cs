using minhaprimeiraapi.Model;

namespace karapinha_xpto_api.Repository.Interfaces
{
    public interface IAppointmentsRepository
    {
        Task<List<AppointmentsModel>> GetAllAppointments();
        Task<AppointmentsModel> GetAppointmentsById(int id);
        Task<AppointmentsModel> AddAppointments(AppointmentsModel appointment);
        Task<AppointmentsModel> UpdateAppointments(AppointmentsModel appointment, int appointmentId);
        Task<bool> DeleteAppointments(int id);
    }
}
