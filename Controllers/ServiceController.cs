using karapinha_xpto_api.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

namespace minhaprimeiraapi.Controllers
{
    [Route("api/services")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServiceModel>>> GetAllServices()
        {
            List<ServiceModel> services = await _serviceRepository.GetAllService();
            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ServiceModel>>> GetUserById(int id)
        {
            ServiceModel services = await _serviceRepository.GetServiceById(id);
            return Ok(services);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceModel>> Register([FromBody] ServiceModel servicesModel)
        {
            ServiceModel services = await _serviceRepository.AddService(servicesModel);
            return Ok(services);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceModel>> Update([FromBody] ServiceModel serviceModel, int id)
        {
            serviceModel.serviceId = id;
            ServiceModel services = await _serviceRepository.UpdateService(serviceModel, id);
            return Ok(services);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceModel>> Delete(int id)
        {
            bool deleted = await _serviceRepository.DeleteService(id);
            return Ok(deleted);
        }
    }
}
