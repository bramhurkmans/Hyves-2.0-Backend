using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProfileService.AsyncDataServices;
using ProfileService.Data;
using ProfileService.Dtos;
using ProfileService.Logic;
using ProfileService.Models;

namespace ProfileService.Controllers
{
    [Route("api/profiles/{profileId}[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongLogic _songLogic;
        private IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public SongController(ISongLogic songLogic, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _songLogic = songLogic;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SongReadDto>> GetSongsByProfile(int profileId)
        {
            Console.WriteLine("Getting songs...");
            var songItems = _songLogic.GetSongs(this.User, profileId);

            return Ok(_mapper.Map<IEnumerable<SongReadDto>>(songItems));
        }

        [HttpPost]
        public async Task<ActionResult<SongReadDto>> CreateSong(SongCreateDto songCreateDto, int profileId)
        {
            Console.WriteLine("Creating song...");

            var songModel = _mapper.Map<Song>(songCreateDto);
            _songLogic.CreateSong(this.User, songModel);

            var songReadDto = _mapper.Map<SongReadDto>(songModel);

            return CreatedAtRoute(null, new { Id = songReadDto.Id }, songReadDto);
        }

        [HttpDelete("{songId}")]
        public async Task<ActionResult<SongReadDto>> RemoveSong(int songId)
        {
            Console.WriteLine("Removing song...");

            _songLogic.DeleteSong(this.User, songId);

            return NoContent();
        }
    } 
}