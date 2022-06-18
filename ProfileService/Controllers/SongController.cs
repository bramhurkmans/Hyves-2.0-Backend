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
using ProfileService.Pagination;

namespace ProfileService.Controllers
{
    [Route("api/profiles/{profileId}/songs")]
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
        [Authorize]
        public ActionResult<IEnumerable<SongReadDto>> GetSongsByProfile(int profileId, [FromQuery] PaginationFilter filter)
        {
            Console.WriteLine("Getting songs..");
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var hobbyItems = _songLogic.GetSongs(this.User, profileId)
                                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                                .Take(validFilter.PageSize)
                                .ToList();

            if (hobbyItems.Count == 0)
            {
                return NoContent();
            }

            var pagedData = _mapper.Map<IEnumerable<SongReadDto>>(hobbyItems);
            var totalRecords = pagedData.Count();

            return Ok(new PagedResponse<IEnumerable<SongReadDto>>(pagedData, validFilter.PageNumber, validFilter.PageSize));
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<SongReadDto>> CreateSong(SongCreateDto songCreateDto, int profileId)
        {
            Console.WriteLine("Creating song...");

            var songModel = _mapper.Map<Song>(songCreateDto);
            _songLogic.CreateSong(this.User, songModel);

            var songReadDto = _mapper.Map<SongReadDto>(songModel);

            return CreatedAtRoute(null, new { Id = songReadDto.Id }, songReadDto);
        }

        [HttpDelete("{songId}")]
        [Authorize]
        public async Task<ActionResult<SongReadDto>> RemoveSong(int songId)
        {
            Console.WriteLine("Removing song...");

            _songLogic.DeleteSong(this.User, songId);

            return NoContent();
        }
    } 
}