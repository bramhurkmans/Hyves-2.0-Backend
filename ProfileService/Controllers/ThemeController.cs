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
    [Route("api/profiles/{profileId}/themes")]
    [ApiController]
    public class ThemeController : ControllerBase
    {
        private readonly IThemeLogic _themeLogic;
        private IMapper _mapper;
        private readonly IMessageBusClient _messageBusClient;

        public ThemeController(IThemeLogic themeLogic, IMapper mapper, IMessageBusClient messageBusClient)
        {
            _themeLogic = themeLogic;
            _mapper = mapper;
            _messageBusClient = messageBusClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ThemeReadDto>> GetThemeProfile(int profileId)
        {
            Console.WriteLine("Getting theme...");
            var themeItem = _themeLogic.GetByProfileId(profileId);

            return Ok(_mapper.Map<ThemeReadDto>(themeItem));
        }

        [HttpPut]
        [Authorize]
        public ActionResult<IEnumerable<ThemeReadDto>> UpdateTheme(int profileId, ThemeUpdateDto themeUpdateDto)
        {
            Console.WriteLine("updating song...");

            var theme = _themeLogic.GetByProfileId(profileId);
            theme.PrimaryColor = themeUpdateDto.PrimaryColor;
            theme.SecondaryColor = themeUpdateDto.SecondaryColor;
            theme.TextColor = themeUpdateDto.TextColor;

            _themeLogic.UpdateTheme(this.User, theme);

            return Ok(_mapper.Map<ThemeReadDto>(theme));
        }
    } 
}