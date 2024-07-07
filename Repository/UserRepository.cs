using Microsoft.EntityFrameworkCore;
using minhaprimeiraapi.Data;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

namespace minhaprimeiraapi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ContextTaskSystemDB _dbContext;
        public UserRepository(ContextTaskSystemDB contextTaskSystemDB) 
        {
            _dbContext = contextTaskSystemDB;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.User.ToListAsync();
        }

        public async Task<UserModel> GetUserById(int id)
        {
            return await _dbContext.User.FirstOrDefaultAsync(x => x.userId == id);
        }

        public async Task<UserModel> AddUser(UserModel user)
        {
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> UpdateUser(UserModel user, int userId)
        {
            UserModel userById = await GetUserById(userId);

            if(userById == null)
            {
                throw new Exception($"User by id: {userId} not found on Data Base");
            }

            userById.fullName = user.fullName;
            userById.userName = user.userName;
            userById.phone = user.phone;
            userById.bi = user.bi;
            userById.Email = user.Email;
            userById.dateCreated = user.dateCreated;
            userById.dateModified = user.dateModified;
            userById.Password = user.Password;
            userById.isActive = user.isActive;
            userById.usertype = user.usertype;

            _dbContext.User.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> DeleteUser(int id)
        {
            UserModel userById = await GetUserById(id);

            if (userById == null)
            {
                throw new Exception($"User by id: {id} not found on Data Base");
            }

            _dbContext.User.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        
    }
}
