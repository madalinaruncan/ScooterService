using ScooterService.Enums;

namespace ScooterService.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public IEnumerable<Reparation> Reparations { get; set; }

    }
}
