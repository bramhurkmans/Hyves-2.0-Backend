using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace UserService.Controllers
{
    [ApiController]
    [Route("health")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<HealthController> _logger;
        private readonly HealthCheckService _service;

        public HealthController(ILogger<HealthController> logger, HealthCheckService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var report = await _service.CheckHealthAsync();

            _logger.LogInformation($"Get Health Information: {report}");

            return report.Status == HealthStatus.Healthy ? Ok(report) : StatusCode((int)HttpStatusCode.ServiceUnavailable, report);
        }
    }
}
