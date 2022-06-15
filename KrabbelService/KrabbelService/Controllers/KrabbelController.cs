using KrabbelService.Data;
using Microsoft.AspNetCore.Mvc;

namespace KrabbelService.Controllers
{
    [ApiController]
    [Route("krabbels")]
    public class KrabbelController : Controller
    {
        private readonly ILogger<KrabbelController> _logger;
        private readonly IKrabbelRepo _krabbelRepo;

        public KrabbelController(ILogger<KrabbelController> logger, IKrabbelRepo krabbelRepo)
        {
            _logger = logger;
            _krabbelRepo = krabbelRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _krabbelRepo.CreateKrabbel(new Models.Krabbel()
            {
                Text = "blablabla",
                Sender = null,
                Receiver = null,
                Date = DateTime.Now
            });

            return Ok();
        }
    }
}
