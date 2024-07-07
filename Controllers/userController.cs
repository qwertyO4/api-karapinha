using Microsoft.AspNetCore.Mvc;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace minhaprimeiraapi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public userController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAllUsers()
        {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserModel>>> GetUserById(int id)
        {
            UserModel users = await _userRepository.GetUserById(id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.AddUser(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {
            userModel.userId = id;
            UserModel user = await _userRepository.UpdateUser(userModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id)
        {
            bool deleted = await _userRepository.DeleteUser(id);
            return Ok(deleted);
        }
    }
}
