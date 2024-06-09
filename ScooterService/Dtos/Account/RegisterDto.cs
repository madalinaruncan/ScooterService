using ScooterService.Entities;
using ScooterService.Enums;
using System.ComponentModel.DataAnnotations;

namespace ScooterService.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Name must be at least {2}, and maximum {1} characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Username must be at least {2}, and maximum {1} characters")]
        public string Username { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6, ErrorMessage = "Password must be at least {2}, and maximum {1} characters")]
        public string PasswordHash { get; set; }
        [Required]
        //[RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,10}$", ErrorMessage ="Invalid email address")]
        public string Email { get; set; }

    }
}
