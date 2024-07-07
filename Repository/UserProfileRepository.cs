using Microsoft.EntityFrameworkCore;
using minhaprimeiraapi.Data;
using minhaprimeiraapi.Model;

namespace karapinha_xpto_api.Repository
{
    public class UserProfileRepository
    {
        private readonly ContextTaskSystemDB _dbContext;

        public UserProfileRepository(ContextTaskSystemDB contextTaskSystemDB)
        {
            _dbContext = contextTaskSystemDB;
        }

        public async Task<List<UserProfileModel>> GetAllUsersProfile()
        {
            return await _dbContext.UserProfile.ToListAsync();
        }

        public async Task<UserProfileModel> GetUserProfileById(int id)
        {
            return await _dbContext.UserProfile.FirstOrDefaultAsync(x => x.userId == id);
        }

        public async Task<UserProfileModel> AddUserProfile(UserProfileModel user)
        {
            await _dbContext.UserProfile.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserProfileModel> UpdateUserProfile(UserProfileModel user, int userId)
        {
            UserProfileModel userProfileById = await GetUserProfileById(userId);

            if (userProfileById == null)
            {
                throw new Exception($"User Profile by id: {userId} not found on Data Base");
            }

            userProfileById.photo = user.photo;
            userProfileById.additionalInfo = user.additionalInfo;

            _dbContext.UserProfile.Update(userProfileById);
            await _dbContext.SaveChangesAsync();

            return userProfileById;
        }

        public async Task<bool> DeleteUserProfile(int id)
        {
            UserProfileModel userProfileById = await GetUserProfileById(id);

            if (userProfileById == null)
            {
                throw new Exception($"User by id: {id} not found on Data Base");
            }

            _dbContext.UserProfile.Remove(userProfileById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
