using AutoMapper;
using ProfileService.Dtos;

namespace ProfileService.Profiles
{
    public class ProfilesProfile : Profile
    {
        public ProfilesProfile()
        {
            CreateMap<ProfileService.Models.Profile, ProfileReadDto>();
        }
    }
}