using ScooterService.Entities;

namespace ScooterService.Service
{
    public interface IUserService
    {

        Task LoginUser(User userObj);
        Task RegisterUser(User userObj);
    }
}
