using AutoMapper;
using KrabbelService.Dtos;

namespace KrabbelService.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<KrabbelService.Models.User, UserReadDto>();
            CreateMap<UserPublishedDto, KrabbelService.Models.User>()
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));
        }
    }
}