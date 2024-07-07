using minhaprimeiraapi.Model;

namespace karapinha_xpto_api.Repository.Interfaces
{
    public interface IEmailsRepository
    {
        Task<List<EmailsModel>> GetAllEmails();
        Task<EmailsModel> GetEmailsById(int id);
        Task<EmailsModel> AddEmails(EmailsModel pro);
        Task<EmailsModel> UpdateEmails(EmailsModel pro, int proid);
        Task<bool> DeleteEmails(int id);
    }
}
