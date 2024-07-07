using minhaprimeiraapi.Model;

namespace karapinha_xpto_api.Repository.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<List<UserProfileModel>> GetAllUsersProfile();
        Task<UserProfileModel> GetUserProfileById(int id);
        Task<UserProfileModel> AddUserProfile(UserProfileModel user);
        Task<UserProfileModel> UpdateUserProfile(UserProfileModel user, int userId);
        Task<bool> DeleteUserProfile(int id);

    }
}

//Deve estar ligada ao usuario final.
