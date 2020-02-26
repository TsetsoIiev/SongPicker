namespace SongPicker.Controllers
{
    using System.Linq;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using SongPicker.Services.Interfaces;
    using SongPicker.Services.Models;

    [Route("api/song")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService songService;

        public SongController(ISongService songService)
        {
            this.songService = songService;
        }

        [HttpPost]
        [Route("/song")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]Song song)
        {
            var result = songService.AddSong(song);

            return Ok(result);
        }

        [HttpGet]
        [Route("/song/{name}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetByName(string name)
        {
            var result = songService.GetByName(name);

            return result != null && result.Any() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("/song/{name}/{argument}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetByAllAttributes(string parameter, int attribute)
        {
            //var result = songService.GetByAttribute(parameter, attribute);

            //return result != null && result.Any() ? (IActionResult)Ok(result) : NotFound();

            return Ok();
        }
    }
}