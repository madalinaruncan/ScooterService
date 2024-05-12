using ScooterService.Entities;
using ScooterService.Enums;

namespace ScooterService.Dtos
{
    public class UserRegisterDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
      
    }
}
