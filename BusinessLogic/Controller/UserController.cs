
using BusinessLogic.Repository;
using Model;

namespace BusinessLogic.Controller
{
    public class UserController
    {
        private readonly UserRepository userRepo;

        public UserController()
        {
            userRepo = new UserRepository();
        }

        public UserModel? ValidateUser(string Username, string Password)
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                throw new Exception("Password/Username cannot be empty.");
            }

            return userRepo.ValidateUser(Username, Password);
        }
    }
}
