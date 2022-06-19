using AutoMapper;
using KrabbelService.Dtos;
using KrabbelService.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace KrabbelService.Controllers
{
    [EnableCors("corsapp")]
    [Route("api/krabbels")]
    [ApiController]
    public class KrabbelController : Controller
    {
        private readonly ILogger<KrabbelController> _logger;
        private readonly IKrabbelLogic _krabbelLogic;
        private IMapper _mapper;
        static readonly HttpClient client = new HttpClient();

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

        [HttpGet("moderate")]
        public async Task<IActionResult> Moderate()
        {
            var krabbels = _krabbelLogic.GetAllKrabbels();

            foreach (var krabbel in krabbels)
            {
                var body = new { text = krabbel.Text };
                try
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Post,
                        RequestUri = new Uri("https://europe-west3-hyves-2-0.cloudfunctions.net/krabbel-moderation"),
                        Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"),
                    };

                    var response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    Console.WriteLine(responseBody);


                    krabbel.Text = responseBody;
                    _krabbelLogic.UpdateKrabbel(krabbel);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    continue;
                }
            }

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
