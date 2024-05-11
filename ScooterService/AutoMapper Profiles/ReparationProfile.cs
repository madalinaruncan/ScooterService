using AutoMapper;
using ScooterService.Dtos;
using ScooterService.Entities;

namespace ScooterService.AutoMapper_Profiles
{
    public class ReparationProfile : Profile
    {
        public ReparationProfile()
        {
            CreateMap<ScooterAddDto, Scooter>();
            CreateMap<IssueAddDto, Issue>();
            CreateMap<ReparationAddDto, Reparation>();
        }
    }
}
