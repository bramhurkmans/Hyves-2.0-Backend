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
using UserService.Logic;

namespace UserService.Controllers
{
    [ApiController]
    [Route("/api/users/friendships")]
    public class FriendshipController : ControllerBase
    {
        private readonly IFriendLogic _friendLogic;
        private readonly IUserLogic _userLogic;
        private IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public FriendshipController(IFriendLogic friendLogic, IUserLogic userLogic, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _friendLogic = friendLogic;
            _userLogic = userLogic;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpPost("/send/{userId}")]
        [Authorize]
        public ActionResult SendRequest(int userId)
        {
            if(_friendLogic.Send(this.User, userId))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPost("/accept/{friendshipId}")]
        [Authorize]
        public ActionResult AcceptFriendShipRequest(int friendshipId)
        {
            if (_friendLogic.Accept(this.User, friendshipId))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPost("/decline/{friendshipId}")]
        [Authorize]
        public ActionResult DeclineFriendShipRequest(int friendshipId)
        {
            if (_friendLogic.Decline(this.User, friendshipId))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpDelete("/{friendshipId}")]
        [Authorize]
        public ActionResult RemoveFriendShip(int friendshipId)
        {
            if (_friendLogic.Delete(this.User, friendshipId))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpGet("/friends/{userId}")]
        [Authorize]
        public ActionResult ListFriendships(int userId)
        {
            var friendships = _friendLogic.List(userId).Where(f => f.FriendRequestFlag == Models.FriendRequestFlag.Approved);

            if(friendships.Count() == 0)
            {
                return NoContent();
            }

            return Ok(friendships);
        }


        [HttpGet("/waiting/{userId}")]
        [Authorize]
        public ActionResult ListWaitingFriendships(int userId)
        {
            var friendships = _friendLogic.List(userId).Where(f => f.FriendRequestFlag == Models.FriendRequestFlag.Waiting);

            if (friendships.Count() == 0)
            {
                return NoContent();
            }

            return Ok(friendships);
        }
    }
}
