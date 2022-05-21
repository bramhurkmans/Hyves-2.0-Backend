using AutoMapper;
using ProfileService.Dtos;

namespace ProfileService.Profiles
{
    public class HobbysProfile : Profile
    {
        public HobbysProfile()
        {
            CreateMap<HobbyCreateDto, ProfileService.Models.Hobby>();
            CreateMap<ProfileService.Models.Hobby, HobbyReadDto>();
        }
    }
}