using karapinha_xpto_api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using minhaprimeiraapi.Data;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

namespace minhaprimeiraapi.Repository
{
    public class AppointmentsRepository : IAppointmentsRepository
    {
        private readonly ContextTaskSystemDB _dbContext;
        public AppointmentsRepository(ContextTaskSystemDB contextTaskSystemDB)
        {
            _dbContext = contextTaskSystemDB;
        }

        public async Task<List<AppointmentsModel>> GetAllAppointments()
        {
            return await _dbContext.Appointments.ToListAsync();
        }

        public async Task<AppointmentsModel> GetAppointmentsById(int id)
        {
            return await _dbContext.Appointments.FirstOrDefaultAsync(x => x.appointmentId == id);
        }

        public async Task<AppointmentsModel> AddAppointments(AppointmentsModel appointment)
        {
            await _dbContext.Appointments.AddAsync(appointment);
            await _dbContext.SaveChangesAsync();

            return appointment;
        }

        public async Task<AppointmentsModel> UpdateAppointments(AppointmentsModel appointments, int appointmentsId)
        {
            AppointmentsModel appointmentsById = await GetAppointmentsById(appointmentsId);

            if (appointmentsById == null)
            {
                throw new Exception($"Emails by id: {appointmentsId} not found on Data Base");
            }

            appointmentsById.professionalId = appointments.professionalId;
            appointmentsById.serviceId = appointments.serviceId;
            appointmentsById.date = appointments.date;
            appointmentsById.time = appointments.time;
            appointmentsById.status_appointment = appointments.status_appointment;

            _dbContext.Appointments.Update(appointmentsById);
            await _dbContext.SaveChangesAsync();

            return appointmentsById;
        }

        public async Task<bool> DeleteAppointments(int id)
        {
            AppointmentsModel AppointmentsById = await GetAppointmentsById(id);

            if (AppointmentsById == null)
            {
                throw new Exception($"Appointment by id: {id} not found on Data Base");
            }

            _dbContext.Appointments.Remove(AppointmentsById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
