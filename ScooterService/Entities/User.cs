using Microsoft.AspNetCore.Identity;
using ScooterService.Enums;
using System.ComponentModel.DataAnnotations;

namespace ScooterService.Entities
{
    public class User : IdentityUser
    {

        public string Name { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public string AccountStatus { get; set; } = "Pending";
        public IEnumerable<Reparation> Reparations { get; set; }

    }
}
