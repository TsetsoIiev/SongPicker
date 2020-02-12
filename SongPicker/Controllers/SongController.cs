namespace SongPicker.Controllers
{
    using System.Threading.Tasks;
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
        public async Task<bool> Post(Song song)
        {
            var result = await songService.AddSong(song);

            return result;
        }
    }
}