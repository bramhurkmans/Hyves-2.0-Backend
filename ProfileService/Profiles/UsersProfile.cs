using AutoMapper;
using ProfileService.Dtos;
using ProfileService.Models;

namespace ProfileService.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            //TODO: finish mappings
            CreateMap<User, UserPublishedDto>();
        }
    }
}