namespace SongPicker.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SongPicker.Services.Interfaces;
    using SongPicker.Services.Models;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            this.playlistService = playlistService;
        }

        [HttpPost]
        [Route("/playlist")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody]PlaylistCreate playlist)
        {
            var result = playlistService.CreatePlaylist(playlist);

            return Ok(result);
        }

        [HttpPost]
        [Route("/playlist/{playlistId}/{songName}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult AddSong(string playlistId, string songName)
        {
            var result = playlistService.AddSongByNameToPlaylist(playlistId, songName);

            return Ok(result);
        }
    }
}