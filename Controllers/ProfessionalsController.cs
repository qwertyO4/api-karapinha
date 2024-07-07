using karapinha_xpto_api.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

namespace minhaprimeiraapi.Controllers
{
    [Route("api/professioanl")]
    [ApiController]
    public class ProfessionalsController : ControllerBase
    {
        private readonly IProfessionalsRepository _professionalsRepository;

        public ProfessionalsController(IProfessionalsRepository professionalsRepository)
        {
            _professionalsRepository = professionalsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProfessionalModel>>> GetAllProfessionals()
        {
            List<ProfessionalModel> professionals = await _professionalsRepository.GetAllProfessional();
            return Ok(professionals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProfessionalModel>>> GetUserById(int id)
        {
            ProfessionalModel professionals = await _professionalsRepository.GetProfessionalsById(id);
            return Ok(professionals);
        }

        [HttpPost]
        public async Task<ActionResult<ProfessionalModel>> Register([FromBody] ProfessionalModel professionalsModel)
        {
            ProfessionalModel professionals = await _professionalsRepository.AddProfessionals(professionalsModel);
            return Ok(professionals);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProfessionalModel>> Update([FromBody] ProfessionalModel professionalsModel, int id)
        {
            professionalsModel.professionalsId = id;
            ProfessionalModel professional = await _professionalsRepository.UpdateProfessionals(professionalsModel, id);
            return Ok(professional);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfessionalModel>> Delete(int id)
        {
            bool deleted = await _professionalsRepository.DeleteProfessionals(id);
            return Ok(deleted);
        }
    }
}
