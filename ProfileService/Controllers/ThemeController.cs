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
    public class ThemeController : ControllerBase
    {
        private readonly IThemeRepo _themeRepo;
        private IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public ThemeController(IThemeRepo themeRepo, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _themeRepo = themeRepo;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ThemeReadDto>> GetThemeProfile(int profileId)
        {
            Console.WriteLine("Getting theme...");
            var themeItem = _themeRepo.GetThemeByProfileId(profileId);

            return Ok(_mapper.Map<ThemeReadDto>(themeItem));
        }

        [HttpGet("{themeId}", Name = "GetThemeById")]
        public ActionResult<ThemeReadDto> GetThemeById(int themeId)
        {
            Console.WriteLine("Getting theme...");
            var themeItem = _themeRepo.GetThemeById(themeId);

            if(themeItem == null) {
                return NotFound();
            }

            return Ok(_mapper.Map<ThemeReadDto>(themeItem));
        }

        [HttpDelete("{themeId}")]
        public async Task<ActionResult<ThemeReadDto>> RemoveTheme(int themeId)
        {
            Console.WriteLine("Removing theme...");

            _themeRepo.RemoveTheme(themeId);
            _themeRepo.SaveChanges();

            return NoContent();
        }
    } 
}