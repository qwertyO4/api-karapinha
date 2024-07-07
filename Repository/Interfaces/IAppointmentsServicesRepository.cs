using minhaprimeiraapi.Model;

namespace karapinha_xpto_api.Repository.Interfaces
{
    public interface IAppointmentsServicesRepository
    {
        Task<List<AppointmentServicesModel>> GetAllAppointmentsServices();
        Task<AppointmentServicesModel> GetAppointmentsServicesById(int id);
        Task<AppointmentServicesModel> AddAppointmentsServices(AppointmentServicesModel appointmentServ);
        Task<AppointmentServicesModel> UpdateAppointmentsServices(AppointmentServicesModel appointmentServ, int appointmentServId);
        Task<bool> DeleteAppointmentsServices(int id);
    }
}
