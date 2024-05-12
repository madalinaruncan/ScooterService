using ScooterService.Entities;

namespace ScooterService.Repository
{
    public interface IUserRepository
    {
        Task LoginUser(User user);
        Task RegisterUser(User user);
    }
}
