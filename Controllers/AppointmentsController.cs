using karapinha_xpto_api.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

namespace minhaprimeiraapi.Controllers
{
    [Route("api/appointsment")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsRepository _appointmentsRepository;

        public AppointmentsController(IAppointmentsRepository appointmentsRepository)
        {
            _appointmentsRepository = appointmentsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AppointmentsModel>>> GetAllAppointments()
        {
            List<AppointmentsModel> appointments = await _appointmentsRepository.GetAllAppointments();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<AppointmentsModel>>> GetAppointmentsById(int id)
        {
            AppointmentsModel appointments = await _appointmentsRepository.GetAppointmentsById(id);
            return Ok(appointments);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentsModel>> Register([FromBody] AppointmentsModel appointmentsModel)
        {
            AppointmentsModel appointments = await _appointmentsRepository.AddAppointments(appointmentsModel);
            return Ok(appointments);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AppointmentsModel>> Update([FromBody] AppointmentsModel appointmentsModel, int id)
        {
            appointmentsModel.appointmentId = id;
            AppointmentsModel appointment = await _appointmentsRepository.UpdateAppointments(appointmentsModel, id);
            return Ok(appointment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AppointmentsModel>> Delete(int id)
        {
            bool deleted = await _appointmentsRepository.DeleteAppointments(id);
            return Ok(deleted);
        }
    }
}
