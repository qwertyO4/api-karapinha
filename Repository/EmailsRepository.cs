using karapinha_xpto_api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using minhaprimeiraapi.Data;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

namespace minhaprimeiraapi.Repository
{
    public class EmailsRepository : IEmailsRepository
    {
        private readonly ContextTaskSystemDB _dbContext;
        public EmailsRepository(ContextTaskSystemDB contextTaskSystemDB)
        {
            _dbContext = contextTaskSystemDB;
        }

        public async Task<List<EmailsModel>> GetAllEmails()
        {
            return await _dbContext.Emails.ToListAsync();
        }

        public async Task<EmailsModel> GetEmailsById(int id)
        {
            return await _dbContext.Emails.FirstOrDefaultAsync(x => x.emailId == id);
        }

        public async Task<EmailsModel> AddEmails(EmailsModel email)
        {
            await _dbContext.Emails.AddAsync(email);
            await _dbContext.SaveChangesAsync();

            return email;
        }

        public async Task<EmailsModel> UpdateEmails(EmailsModel email, int emailsId)
        {
            EmailsModel emailsById = await GetEmailsById(emailsId);

            if (emailsById == null)
            {
                throw new Exception($"Emails by id: {emailsId} not found on Data Base");
            }

            emailsById.to = email.to;
            emailsById.subject = email.subject;
            emailsById.body = email.body;
            emailsById.statusEmail = email.statusEmail;

            _dbContext.Emails.Update(emailsById);
            await _dbContext.SaveChangesAsync();

            return emailsById;
        }

        public async Task<bool> DeleteEmails(int id)
        {
            EmailsModel EmailsById = await GetEmailsById(id);

            if (EmailsById == null)
            {
                throw new Exception($"Emails by id: {id} not found on Data Base");
            }

            _dbContext.Emails.Remove(EmailsById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
