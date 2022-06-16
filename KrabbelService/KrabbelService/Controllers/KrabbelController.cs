using AutoMapper;
using KrabbelService.Data;
using KrabbelService.Dtos;
using KrabbelService.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KrabbelService.Controllers
{
    [ApiController]
    [Route("krabbels")]
    public class KrabbelController : Controller
    {
        private readonly ILogger<KrabbelController> _logger;
        private readonly IKrabbelLogic _krabbelLogic;
        private IMapper _mapper;

        public KrabbelController(ILogger<KrabbelController> logger, IMapper mapper, IKrabbelLogic krabbelLogic)
        {
            _logger = logger;
            _mapper = mapper;
            _krabbelLogic = krabbelLogic;
        }

        [HttpPost("users/{userId}")]
        [Authorize]
        public async Task<IActionResult> CreateKrabbel(int userId, KrabbelCreateDto krabbelCreateDto)
        {
            Console.WriteLine("Creating krabbel...");

            if (_krabbelLogic.Createkrabbel(this.User, userId, krabbelCreateDto.Text))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("users/{userId}")]
        public async Task<IActionResult> GetKrabbelsByUser(int userId)
        {
            var krabbels = _krabbelLogic.GetKrabbels(userId);

            return Ok(krabbels);
        }

        [HttpDelete("{krabbelId}")]
        public async Task<IActionResult> RemoveKrabbel(int krabbelId)
        {
            _krabbelLogic.RemoveKrabbel(this.User, krabbelId);

            return Ok();
        }
    }
}
