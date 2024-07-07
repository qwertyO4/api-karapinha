using Microsoft.EntityFrameworkCore;
using minhaprimeiraapi.Data;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

namespace minhaprimeiraapi.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ContextTaskSystemDB _dbContext;
        public ServiceRepository(ContextTaskSystemDB contextTaskSystemDB)
        {
            _dbContext = contextTaskSystemDB;
        }

        public async Task<List<ServiceModel>> GetAllService()
        {
            return await _dbContext.Services.ToListAsync();
        }

        public async Task<ServiceModel> GetServiceById(int id)
        {
            return await _dbContext.Services.FirstOrDefaultAsync(x => x.serviceId == id);
        }

        public async Task<ServiceModel> AddService(ServiceModel service)
        {
            await _dbContext.Services.AddAsync(service);
            await _dbContext.SaveChangesAsync();

            return service;
        }

        public async Task<bool> DeleteService(int id)
        {
            ServiceModel serviceById = await GetServiceById(id);

            if (serviceById == null)
            {
                throw new Exception($"Service by id: {id} not found on Data Base");
            }

            _dbContext.Services.Remove(serviceById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<ServiceModel> UpdateService(ServiceModel services, int serviceId)
        {
            ServiceModel serviceById = await GetServiceById(serviceId);

            if (serviceById == null)
            {
                throw new Exception($"Service by id: {serviceId} not found on Data Base");
            }

            serviceById.serviceName = services.serviceName;
            serviceById.category = services.category;
            serviceById.price = services.price;
            serviceById.serviceDescription = services.serviceDescription;

            _dbContext.Services.Update(serviceById);
            await _dbContext.SaveChangesAsync();

            return serviceById;
        }
    }
}
