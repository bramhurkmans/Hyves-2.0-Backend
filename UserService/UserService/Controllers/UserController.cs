using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserService.AsyncDataServices;
using UserService.Data;
using UserService.Dtos;
using UserService.Logic;

namespace UserService.Controllers
{
    [ApiController]
    [Route("/api/users")]
        public class UserController : ControllerBase
        {
        private readonly IUserLogic _userLogic;
        // private readonly UserRepo _userRepo;
        private IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public UserController(IUserLogic userLogic, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _userLogic = userLogic;
            // _userRepo = userRepo;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet("me")]
        [Authorize]
        public ActionResult<string> GetCurrentUser()
        {
            var user = _userLogic.GetUser(this.User);

            return Ok(user);
        }

        // [HttpGet]
        // //[Authorize(Roles = "hyves2-admin")]
        // public ActionResult<IEnumerable<UserReadDto>> GetUsers()
        // {
        //     var userItems = _userRepo.GetAllUsers();

        //     return Ok(_mapper.Map<IEnumerable<UserReadDto>>(userItems));
        // }
    }
}
