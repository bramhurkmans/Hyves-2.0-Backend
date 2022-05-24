using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService.AsyncDataServices;
using UserService.Data;
using UserService.Dtos;

namespace UserService.Controllers
{
    [ApiController]
    [Route("/api/users/{id}/[controller]")]
    public class FriendController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public FriendController(IUserRepo userRepo, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<string> Get()
        {
            return this.User.Identity.Name;
        }

        [HttpGet("{userId}", Name = "GetFriendsByUserId")]
        [Authorize]
        public ActionResult<IEnumerable<UserReadDto>> getFriends()
        {
            var userItems = _userRepo.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        }
    }
}
