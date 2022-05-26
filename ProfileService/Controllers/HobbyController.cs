using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfileService.AsyncDataServices;
using ProfileService.Data;
using ProfileService.Dtos;
using ProfileService.Logic;
using ProfileService.Models;

namespace ProfileService.Controllers
{
    [Route("api/profiles/{profileId}/hobbies")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private readonly IHobbyLogic _hobbyLogic;
        private IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public HobbyController(IHobbyLogic hobbyLogic, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _hobbyLogic = hobbyLogic;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<HobbyReadDto>> GetHobbiesByProfile(int profileId)
        {
            Console.WriteLine("Getting hobbies...");
            var hobbyItems = _hobbyLogic.GetHobbies(this.User, profileId);

            if(hobbyItems.Count == 0)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IEnumerable<HobbyReadDto>>(hobbyItems));
        }


        [HttpPost]
        [Authorize]
        public async Task<ActionResult<HobbyReadDto>> CreateHobby(HobbyCreateDto hobbyCreateDto)
        {
            Console.WriteLine("Creating Hobby...");

            var hobbyModel = _mapper.Map<Hobby>(hobbyCreateDto);
            _hobbyLogic.CreateHobby(this.User, hobbyModel);

            var hobbyReadDto = _mapper.Map<HobbyReadDto>(hobbyModel);

            return CreatedAtRoute(null, new { Id = hobbyReadDto.Id }, hobbyReadDto);
        }



        [HttpDelete("{hobbyId}")]
        [Authorize]
        public async Task<ActionResult<HobbyReadDto>> DeleteHobby(int hobbyId)
        {
            Console.WriteLine("Deleting hobby...");

            _hobbyLogic.DeleteHobby(this.User, hobbyId);

            return NoContent();
        }
    } 
}