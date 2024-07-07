using minhaprimeiraapi.Model;

namespace minhaprimeiraapi.Repository.Interfaces
{
    public interface IServiceRepository
    {
        Task<List<ServiceModel>> GetAllService();
        Task<ServiceModel> GetServiceById(int id);
        Task<ServiceModel> AddService(ServiceModel service);
        Task<ServiceModel> UpdateService(ServiceModel service, int serviceId);
        Task<bool> DeleteService(int id);
    }
}
