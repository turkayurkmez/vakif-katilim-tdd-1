using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Speakers.Service;

namespace Speakers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerService speakerService;

        public SpeakerController(ISpeakerService speakerService)
        {
            this.speakerService = speakerService;
        }
        [HttpGet]
        public IActionResult Search(string value)
        {
         

            var searchResult = speakerService.SearchSpeakersByName(value);

            return Ok(searchResult);
        }
    }
}
