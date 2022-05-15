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
    public class SongController : ControllerBase
    {
        private readonly ISongRepo _songRepo;
        private IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public SongController(ISongRepo songRepo, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _songRepo = songRepo;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SongReadDto>> GetSongsByProfile(int profileId)
        {
            Console.WriteLine("Getting songs...");
            var songItems = _songRepo.getSongsByProfileId(profileId);

            return Ok(_mapper.Map<IEnumerable<SongReadDto>>(songItems));
        }

        [HttpGet("{songId}", Name = "GetSongById")]
        public ActionResult<SongReadDto> GetSongById(int songId)
        {
            Console.WriteLine("Getting song...");
            var songItem = _songRepo.GetSongById(songId);

            if(songItem == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<SongReadDto>(songItem));
        }

        [HttpPost]
        public async Task<ActionResult<SongReadDto>> CreateSong(SongCreateDto songCreateDto, int profileId)
        {
            Console.WriteLine("Creating song...");

            var songModel = _mapper.Map<Song>(songCreateDto);
            _songRepo.CreateSong(songModel);
            _songRepo.SaveChanges();

            var songReadDto = _mapper.Map<SongReadDto>(songModel);

            return CreatedAtRoute(nameof(GetSongById), new { Id = songReadDto.Id }, songReadDto);
        }

        [HttpDelete("{songId}")]
        public async Task<ActionResult<SongReadDto>> RemoveSong(int songId)
        {
            Console.WriteLine("Removing song...");

            _songRepo.RemoveSong(songId);
            _songRepo.SaveChanges();

            return NoContent();
        }
    } 
}