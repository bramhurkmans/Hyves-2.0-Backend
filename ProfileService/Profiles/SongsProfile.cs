using AutoMapper;
using ProfileService.Dtos;

namespace ProfileService.Profiles
{
    public class SongsProfile : Profile
    {
        public SongsProfile()
        {
            CreateMap<SongCreateDto, ProfileService.Models.Song>();
            CreateMap<ProfileService.Models.Song, SongReadDto>();
        }
    }
}