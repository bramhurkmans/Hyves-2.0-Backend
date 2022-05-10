using AutoMapper;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();

            //For messaging
            CreateMap<UserReadDto, User>();

            CreateMap<UserPublishedDto, User>();
                //.ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.Id));
        }
    }
}