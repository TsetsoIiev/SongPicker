using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using SongPicker.Services.Enums;
using SongPicker.Services.Interfaces;
using SongPicker.Services.Models;

namespace SongPicker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISongService songService;

        public SongController(ISongService songService)
        {
            this.songService = songService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]SongCreate song)
        {
            var result = songService.AddSong(song);

            return Ok(result);
        }

        [HttpGet]
        public IEnumerable<Song> Get()
        {
            var result = songService.GetAll();

            return result;
        }

        [HttpGet]
        [Route("[controller]/query")]
        public IEnumerable<Song> GetByAttributes(string name, string artist, string genre, string album, string yearFrom, string yearTo)
        {
            var result = songService.GetByAttributes(name, artist, album, genre, yearFrom, yearTo);

            return result;
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
        public IActionResult GetbyAttribute(string parameter, SongAttribute attribute)
        {
            var result = songService.GetByAttribute(parameter, attribute);

            return result != null && result.Any() ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpGet]
        [Route("/song")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetByAllAttributes(string parameter)
        {
            var result = songService.GetByAllAttributes(parameter);

            return result != null && result.Any() ? (IActionResult)Ok(result) : NotFound();
        }
    }
}