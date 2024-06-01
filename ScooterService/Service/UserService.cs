using ScooterService.Entities;
using ScooterService.Repository;


namespace ScooterService.Service
{
    public class UserService : IUserService
    { 
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) { 
            _userRepository = userRepository;
        }
                  
    
        public async Task LoginUser(User userObj)
        {
            userObj.Token = "";
            userObj.Role = Enums.UserRole.Mechanic;
            userObj.Reparations = [];
            await _userRepository.LoginUser(userObj);
        }

        public async Task RegisterUser(User userObj)
        {
            
            await _userRepository.RegisterUser(userObj);
        }
    }
}
