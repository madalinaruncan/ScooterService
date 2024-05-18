using Microsoft.AspNetCore.Identity;
using ScooterService.Enums;
using System.ComponentModel.DataAnnotations;

namespace ScooterService.Entities
{
    public class User : IdentityUser
    {

        public string Name { get; set; }
        public IEnumerable<Reparation> Reparations { get; set; }

    }
}
