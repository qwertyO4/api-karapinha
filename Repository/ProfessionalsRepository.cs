using karapinha_xpto_api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using minhaprimeiraapi.Data;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

namespace minhaprimeiraapi.Repository
{
    public class ProfessionalsRepository : IProfessionalsRepository
    {
        private readonly ContextTaskSystemDB _dbContext;
        public ProfessionalsRepository(ContextTaskSystemDB contextTaskSystemDB)
        {
            _dbContext = contextTaskSystemDB;
        }

        public async Task<List<ProfessionalModel>> GetAllProfessional()
        {
            return await _dbContext.Professional.ToListAsync();
        }

        public async Task<ProfessionalModel> GetProfessionalsById(int id)
        {
            return await _dbContext.Professional.FirstOrDefaultAsync(x => x.professionalsId == id);
        }

        public async Task<ProfessionalModel> AddProfessionals(ProfessionalModel professional)
        {
            await _dbContext.Professional.AddAsync(professional);
            await _dbContext.SaveChangesAsync();

            return professional;
        }

        public async Task<ProfessionalModel> UpdateProfessionals(ProfessionalModel professional, int professionalId)
        {
            ProfessionalModel professionalById = await GetProfessionalsById(professionalId);

            if (professionalById == null)
            {
                throw new Exception($"Professional by id: {professionalId} not found on Data Base");
            }

            professionalById.fullName = professional.fullName;
            professionalById.phone = professional.phone;
            professionalById.bi = professional.bi;
            professionalById.Email = professional.Email;
            professionalById.photo = professional.photo;
            professionalById.workingHours = professional.workingHours;

            _dbContext.Professional.Update(professionalById);
            await _dbContext.SaveChangesAsync();

            return professionalById;
        }

        public async Task<bool> DeleteProfessionals(int id)
        {
            ProfessionalModel professionalById = await GetProfessionalsById(id);

            if (professionalById == null)
            {
                throw new Exception($"Professional by id: {id} not found on Data Base");
            }

            _dbContext.Professional.Remove(professionalById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
