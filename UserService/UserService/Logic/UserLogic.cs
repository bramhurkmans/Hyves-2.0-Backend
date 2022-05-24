using System.Security.Claims;
using AutoMapper;
using UserService.AsyncDataServices;
using UserService.Data;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepo _userRepo;
        private readonly IMessageBusClient _messageBusClient;
        private readonly IMapper _mapper;

        public UserLogic(IUserRepo userRepo, IMessageBusClient messageBusClient, IMapper mapper)
        {
            _userRepo = userRepo;
            _messageBusClient = messageBusClient;
            _mapper = mapper;
        }
        public User GetUser(ClaimsPrincipal claimsPrincipal)
        {
            var user = _userRepo.GetUserByKeycloakIdentifier(claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value);

            if(user == null)
            {
                var newUser = new User()
                {
                    isPrivate = false,
                    KeyCloakIdentifier = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value,
                    Email = claimsPrincipal.FindFirst(ClaimTypes.Email).Value,
                    FirstName = claimsPrincipal.FindFirst(ClaimTypes.GivenName).Value,
                    LastName = claimsPrincipal.FindFirst(ClaimTypes.Surname).Value,
                    UserName = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value,
                };

                _userRepo.CreateUser(newUser);
                _userRepo.SaveChanges();

                var platformPublishedDto = _mapper.Map<UserPublishedDto>(newUser);
                platformPublishedDto.Event = "User_Published";

                _messageBusClient.PublishNewPlatform(platformPublishedDto);

                return newUser;
            }

            return user;
        }
    }
}