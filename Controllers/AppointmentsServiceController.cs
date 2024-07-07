using karapinha_xpto_api.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

namespace minhaprimeiraapi.Controllers
{
    [Route("api/appointsmentservice")]
    [ApiController]
    public class AppointmentsServiceController : ControllerBase
    {
        private readonly IAppointmentsServicesRepository _appointmentsRepository;

        public AppointmentsServiceController(IAppointmentsServicesRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AppointmentServicesModel>>> GetAllAppointmentsService()
        {
            List<AppointmentServicesModel> appointments = await _appointmentsRepository.GetAllAppointmentsServices();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<AppointmentServicesModel>>> GetAppointmentsById(int id)
        {
            AppointmentServicesModel appointments = await _appointmentsRepository.GetAppointmentsServicesById(id);
            return Ok(appointments);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentServicesModel>> Register([FromBody] AppointmentServicesModel appointmentsServiceModel)
        {
            AppointmentServicesModel appointments = await _appointmentsRepository.AddAppointmentsServices(appointmentsServiceModel);
            return Ok(appointments);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AppointmentServicesModel>> Update([FromBody] AppointmentServicesModel appointmentsServicesModel, int id)
        {
            appointmentsServicesModel.appointmentId = id;
            AppointmentServicesModel appointment = await _appointmentsRepository.UpdateAppointmentsServices(appointmentsServicesModel, id);
            return Ok(appointment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AppointmentServicesModel>> Delete(int id)
        {
            bool deleted = await _appointmentsRepository.DeleteAppointmentsServices(id);
            return Ok(deleted);
        }
    }
}
