using karapinha_xpto_api.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using minhaprimeiraapi.Model;
using minhaprimeiraapi.Repository.Interfaces;

namespace karapinha_xpto_api.Controllers
{
    [Route("api/userprofile")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserProfileModel>>> GetAllUsersProfile()
        {
            List<UserProfileModel> usersprofile = await _userProfileRepository.GetAllUsersProfile();
            return Ok(usersprofile);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserProfileModel>>> GetUserById(int id)
        {
            UserProfileModel usersprofile = await _userProfileRepository.GetUserProfileById(id);
            return Ok(usersprofile);
        }

        [HttpPost]
        public async Task<ActionResult<UserProfileModel>> Register([FromBody] UserProfileModel userProfileModel)
        {
            UserProfileModel userprofile = await _userProfileRepository.AddUserProfile(userProfileModel);
            return Ok(userprofile);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserProfileModel>> Update([FromBody] UserProfileModel userProfileModel, int id)
        {
            userProfileModel.userId = id;
            UserProfileModel userprofile = await _userProfileRepository.UpdateUserProfile(userProfileModel, id);
            return Ok(userprofile);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserProfileModel>> Delete(int id)
        {
            bool deleted = await _userProfileRepository.DeleteUserProfile(id);
            return Ok(deleted);
        }
    }
}
