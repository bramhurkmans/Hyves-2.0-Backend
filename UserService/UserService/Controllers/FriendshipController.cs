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
    [Route("/api/users/friendships")]
    public class FriendshipController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        private IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public FriendshipController(IUserRepo userRepo, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpPost("send/{userId}")]
        [Authorize]
        public ActionResult<string> sendRequest()
        {
            return this.User.Identity.Name;
        }

        [HttpPost("accept/{friendshipId}")]
        [Authorize]
        public ActionResult<string> acceptFriendShipRequest()
        {
            return this.User.Identity.Name;
        }

        [HttpPost("decline/{friendshipId}")]
        [Authorize]
        public ActionResult<string> declineFriendShipRequest()
        {
            return this.User.Identity.Name;
        }

        [HttpDelete("{friendshipId}")]
        [Authorize]
        public ActionResult<string> removeFriendShip()
        {
            return this.User.Identity.Name;
        }
    }
}
