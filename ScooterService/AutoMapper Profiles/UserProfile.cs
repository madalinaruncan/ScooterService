using AutoMapper;
using ScooterService.Dtos;
using ScooterService.Entities;

namespace ScooterService.AutoMapper_Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<UserLoginDto, User>();
        }
    }
}
