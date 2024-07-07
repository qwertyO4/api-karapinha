using minhaprimeiraapi.Enums;

namespace minhaprimeiraapi.Model
{
    public class UserModel
    {
         
        public int userId { get; set; }
        public string fullName { get; set; }
        public string Email { get; set; }
        public string phone {  get; set; }
        public string bi { get; set; }
        public string Password { get; set; }
        public string userName { get; set; }
        public UserType usertype { get; set; }
        public bool isActive { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}
