using karapinha_xpto_api.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

namespace minhaprimeiraapi.Controllers
{
    [Route("api/emails")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly IEmailsRepository _emailsRepository;

        public EmailsController(IEmailsRepository emailsRepository)
        {
            _emailsRepository = emailsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<EmailsModel>>> GetAllEmails()
        {
            List<EmailsModel> emails = await _emailsRepository.GetAllEmails();
            return Ok(emails);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<EmailsModel>>> GetEmailsById(int id)
        {
            EmailsModel emails = await _emailsRepository.GetEmailsById(id);
            return Ok(emails);
        }

        [HttpPost]
        public async Task<ActionResult<EmailsModel>> Register([FromBody] EmailsModel emailsModel)
        {
            EmailsModel emails = await _emailsRepository.AddEmails(emailsModel);
            return Ok(emails);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmailsModel>> Update([FromBody] EmailsModel emailsModel, int id)
        {
            emailsModel.emailId = id;
            EmailsModel emails = await _emailsRepository.UpdateEmails(emailsModel , id);
            return Ok(emails);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmailsModel>> Delete(int id)
        {
            bool deleted = await _emailsRepository.DeleteEmails(id);
            return Ok(deleted);
        }
    }
}
