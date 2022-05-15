using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.AsyncDataServices;
using ProfileService.Data;
using ProfileService.Dtos;
using ProfileService.Models;

namespace ProfileService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepo _profileRepo;
        private IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public ProfileController(IProfileRepo profileRepo, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _profileRepo = profileRepo;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProfileReadDto>> getProfiles()
        {
            Console.WriteLine("Getting profiles...");
            var platformItems = _profileRepo.GetAllProfiles();

            return Ok(_mapper.Map<IEnumerable<ProfileReadDto>>(platformItems));
        }

        [HttpGet("{id}", Name = "GetProfileById")]
        public ActionResult<ProfileReadDto> GetProfileById(int id)
        {
            Console.WriteLine("Getting profile...");
            var platformItem = _profileRepo.GetProfileById(id);

            if(platformItem == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<ProfileReadDto>(platformItem));
        }
    } 
}