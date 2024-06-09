using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ScooterService.Data;
using ScooterService.Entities;
using System.Security.Claims;

namespace ScooterService.Service
{
    public class ContextSeedService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ContextSeedService(AppDbContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitializeContextAsync()
        {
            if (_context.Database.GetPendingMigrationsAsync().GetAwaiter().GetResult().Count() > 0)
            {
                // applies any pending migration into our database
                await _context.Database.MigrateAsync();
            }

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = SD.AdminRole });
                await _roleManager.CreateAsync(new IdentityRole { Name = SD.MechanicRole });
            }

            if (!_userManager.Users.AnyAsync().GetAwaiter().GetResult())
            {

                var mechanic = new User
                {
                    Name = "Mechanic",
                    UserName = "M100",
                    Email = "mechanic@es.com",
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(mechanic, "123456");
                await _userManager.AddToRoleAsync(mechanic, SD.MechanicRole);
                await _userManager.AddClaimsAsync(mechanic, new Claim[]
                {
                    new Claim(ClaimTypes.Email, mechanic.Email),
                    new Claim(ClaimTypes.Name, mechanic.UserName)
                });

                var admin = new User
                {
                    Name = "Admin",
                    UserName = "A100",
                    Email = "admin@es.com",
                    EmailConfirmed = true,
                    AccountStatus = "Confirmed"
                };
                await _userManager.CreateAsync(admin, "123456");
                await _userManager.AddToRoleAsync(admin, SD.AdminRole);
                await _userManager.AddClaimsAsync(admin, new Claim[]
                {
                    new Claim(ClaimTypes.Email, admin.Email),
                    new Claim(ClaimTypes.Name, admin.UserName)
                });


            }
        }
    }
}
