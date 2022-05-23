using AutoMapper;
using ProfileService.Dtos;

namespace ProfileService.Profiles
{
    public class ThemesProfile : Profile
    {
        public ThemesProfile()
        {
            CreateMap<ProfileService.Models.Theme, ThemeReadDto>();
        }
    }
}