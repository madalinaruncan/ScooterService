using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScooterService.Entities;
using ScooterService.Enums;
using System.Reflection;

namespace ScooterService.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public DbSet<User> Users { get; set; }
        public DbSet<Scooter> Scooters { get; set; }
        public DbSet<Reparation> Reparations { get; set; }
        public DbSet<Issue> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = "1",
                    Name = "Allan",
                    UserName = "Allan",
                    PasswordHash = "ascrvdvs",
                    Email = "allan.service@gmail.com",
                    //Role = UserRole.Mechanic
                }
           );
        }
    }
}
