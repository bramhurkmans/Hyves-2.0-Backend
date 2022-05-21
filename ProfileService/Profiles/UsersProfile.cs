using AutoMapper;
using ProfileService.Dtos;

namespace ProfileService.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<ProfileService.Models.User, UserReadDto>();
            CreateMap<UserPublishedDto, ProfileService.Models.User>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));
        }
    }
}