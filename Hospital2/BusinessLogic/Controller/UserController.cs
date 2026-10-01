using Hospital2.BusinessLogic.Repository;
using Hospital2.Model;

namespace Hospital2.BusinessLogic.Controller
{
    internal class UserController
    {

        private UserRepository userRepo;

        public UserController()
        {
            userRepo = new UserRepository();
        }


        public UserModel ValidateUser(string Username, string Password)
        {
   
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                throw new Exception("Password/Username cannot be empty.");
            }
            return userRepo.ValidateUser(Username, Password);
        }
    }
}