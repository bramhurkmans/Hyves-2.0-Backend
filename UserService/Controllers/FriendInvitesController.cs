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
    public class FriendInvitesController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public FriendInvitesController(IUserRepo userRepo, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<UserReadDto>> GetFriendInvites()
        {
            var userItems = _userRepo.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        }

        [HttpPost("accept")]
        [Authorize]
        public ActionResult<string> AcceptFriendInvite()
        {
            var userItems = _userRepo.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        }
    }
}
