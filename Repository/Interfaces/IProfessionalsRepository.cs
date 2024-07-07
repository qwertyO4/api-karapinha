using minhaprimeiraapi.Model;

namespace karapinha_xpto_api.Repository.Interfaces
{
    public interface IProfessionalsRepository
    {
        Task<List<ProfessionalModel>> GetAllProfessional();
        Task<ProfessionalModel> GetProfessionalsById(int id);
        Task<ProfessionalModel> AddProfessionals(ProfessionalModel pro);
        Task<ProfessionalModel> UpdateProfessionals(ProfessionalModel pro, int proId);
        Task<bool> DeleteProfessionals(int id);
    }
}
