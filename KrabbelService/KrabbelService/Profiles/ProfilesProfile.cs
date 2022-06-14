using AutoMapper;
using KrabbelService.Dtos;

namespace KrabbelService.Profiles
{
    public class KrabbelsProfile : Profile
    {
        public KrabbelsProfile()
        {
            CreateMap<KrabbelService.Models.Krabbel, KrabbelReadDto>();
        }
    }
}