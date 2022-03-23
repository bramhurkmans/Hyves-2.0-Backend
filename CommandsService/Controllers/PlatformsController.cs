using System;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers
{
    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {
            
        }

        [HttpPost]
        public ActionResult TestInboundConection()
        {
            Console.WriteLine("Inbound POST at the # command service!");

            return Ok("inbound test from platforms controller");
        }
    }
}