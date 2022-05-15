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
    [Route("api/profiles/{profileId}[controller]")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly IHobbyRepo _hobbyRepo;
        private IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public HobbyController(IHobbyRepo hobbyRepo, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _hobbyRepo = hobbyRepo;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HobbyReadDto>> GetHobbiesByProfile(int profileId)
        {
            Console.WriteLine("Getting hobbies...");
            var hobbyItems = _hobbyRepo.getHobbiesByProfileId(profileId);

            return Ok(_mapper.Map<IEnumerable<HobbyReadDto>>(hobbyItems));
        }

        [HttpGet("{hobbyId}", Name = "GetHobbyById")]
        public ActionResult<HobbyReadDto> GetHobbyById(int hobbyId)
        {
            Console.WriteLine("Getting hobby...");
            var hobbyItem = _hobbyRepo.GetHobbyById(hobbyId);

            if(hobbyItem == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<HobbyReadDto>(hobbyItem));
        }

        [HttpPost]
        public async Task<ActionResult<HobbyReadDto>> CreateHobby(HobbyCreateDto hobbyCreateDto, int profileId)
        {
            Console.WriteLine("Creating platform...");

            var hobbyModel = _mapper.Map<Hobby>(hobbyCreateDto);
            _hobbyRepo.CreateHobby(hobbyModel);
            _hobbyRepo.SaveChanges();

            var platformReadDto = _mapper.Map<HobbyReadDto>(hobbyModel);

            return CreatedAtRoute(nameof(GetHobbyById), new { Id = platformReadDto.Id }, platformReadDto);
        }

        [HttpDelete("{hobbyId}")]
        public async Task<ActionResult<HobbyReadDto>> DeleteHobby(int hobbyId)
        {
            Console.WriteLine("Deleting hobby...");

            _hobbyRepo.RemoveHobby(hobbyId);
            _hobbyRepo.SaveChanges();

            return NoContent();
        }
    } 
}