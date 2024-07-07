using karapinha_xpto_api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using minhaprimeiraapi.Data;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

namespace minhaprimeiraapi.Repository
{
    public class AppointmentsServicesRepository : IAppointmentsServicesRepository
    {
        private readonly ContextTaskSystemDB _dbContext;
        public AppointmentsServicesRepository(ContextTaskSystemDB contextTaskSystemDB)
        {
            _dbContext = contextTaskSystemDB;
        }

        public async Task<List<AppointmentServicesModel>> GetAllAppointmentsServices()
        {
            return await _dbContext.AppointmentServices.ToListAsync();
        }

        public async Task<AppointmentServicesModel> GetAppointmentsServicesById(int id)
        {
            return await _dbContext.AppointmentServices.FirstOrDefaultAsync(x => x.appointmentServiceId == id);
        }

        public async Task<AppointmentServicesModel> AddAppointmentsServices(AppointmentServicesModel appointmentServ)
        {
            await _dbContext.AppointmentServices.AddAsync(appointmentServ);
            await _dbContext.SaveChangesAsync();

            return appointmentServ;
        }

        public async Task<AppointmentServicesModel> UpdateAppointmentsServices(AppointmentServicesModel appointmentServ, int appointmentServId)
        {
            AppointmentServicesModel appointmentsServById = await GetAppointmentsServicesById(appointmentServId);

            if (appointmentsServById == null)
            {
                throw new Exception($"Appointment Service  by id: {appointmentServId} not found on Data Base");
            }

            appointmentsServById.serviceId = appointmentServ.serviceId;
            appointmentsServById.appointmentId = appointmentServ.appointmentId;

            _dbContext.AppointmentServices.Update(appointmentsServById);
            await _dbContext.SaveChangesAsync();

            return appointmentsServById;
        }

        public async Task<bool> DeleteAppointmentsServices(int id)
        {
            AppointmentServicesModel AppointmentsById = await GetAppointmentsServicesById(id);

            if (AppointmentsById == null)
            {
                throw new Exception($"Appointment Service by id: {id} not found on Data Base");
            }

            _dbContext.AppointmentServices.Remove(AppointmentsById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
