using AutoMapper;
using ScooterService.Dtos.Account;
using ScooterService.Entities;

namespace ScooterService.AutoMapper_Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDto, User>();
            CreateMap<LoginDto, User>();
        }
    }
}
