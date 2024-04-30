using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Speakers.Domain;
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

        public IActionResult Get(int id)
        {
            var speaker = speakerService.GetSpeaker(id);
            return Ok(speaker);
        }

        [HttpPost]
        public IActionResult Create(Speaker speaker)
        {
            var newSpeaker = speakerService.Create(speaker);
            return CreatedAtAction(nameof(Get), new { id = newSpeaker.Id }, newSpeaker);
        }
    }
}
